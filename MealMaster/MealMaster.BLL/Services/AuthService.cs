using AutoMapper;
using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.Auth;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Helpers;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;
using MealMaster.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace MealMaster.BLL.Services;

public class AuthService:IAuthService
{
    private readonly ILogger<AuthService> _logger;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(
        ILogger<AuthService> logger, 
        IMapper mapper, 
        ITokenService tokenService, 
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mapper = mapper;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }
    
    private async Task<User> FindUserByNameOrThrowAsync(string name,CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByNameAsync(name, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException($"User with name : {name} is not found");
        }

        return user;
    }

    private void CheckPassword(string oldPassword, string newPassword)
    {
        var isPasswordCorrect = PasswordHelper.VerifyPassword(oldPassword, newPassword);
        if (!isPasswordCorrect)
        {
            throw new AuthorizationException("Password is incorrect");
        }
    }

    public async Task LogoutAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByRefreshTokenAsync(refreshToken, cancellationToken);

        if (user is null)
        {
            throw new EntityNotFoundException("User not found");
        }

        user.RefreshToken = string.Empty;
        user.RefreshTokenExpiryTime = DateTime.MinValue;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Successfully logged out");
    }

    public async Task<AuthResponseDto> AuthenticateAsync(LoginDto loginDto, CancellationToken cancellationToken = default)
    {
        var user = await FindUserByNameOrThrowAsync(loginDto.Username,cancellationToken);
        
        CheckPassword(user.PasswordHash, loginDto.Password);
        
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshTokenModel = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshTokenModel.RefreshToken;
        user.RefreshTokenExpiryTime = refreshTokenModel.RefreshTokenExireTime;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AuthResponseDto(){RefreshToken = refreshTokenModel.RefreshToken,AccessToken = accessToken,UserId = user.Id};

    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerUserDto, CancellationToken cancellationToken = default)
    {
        var userFromDb = await _unitOfWork.Users.GetByNameAsync(registerUserDto.Username, cancellationToken);
        
        if (userFromDb is not null)
        {
            throw new AlreadyExistsException("user", "username", registerUserDto.Username);
        }
        
        var user = _mapper.Map<User>(registerUserDto);
        user.PasswordHash = PasswordHelper.HashPassword(registerUserDto.Password);
        
        await _unitOfWork.Users.CreateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        _logger.LogInformation( "Successful user registration");
        
        return await AuthenticateAsync(_mapper.Map<LoginDto>(registerUserDto));
    }

    public async Task<AuthResponseDto> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByRefreshTokenAsync(refreshToken, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException("User not found");
        }
        
        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshTokenModel = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshTokenModel.RefreshToken;
        user.RefreshTokenExpiryTime = refreshTokenModel.RefreshTokenExireTime;

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthResponseDto() { RefreshToken = refreshToken, AccessToken = accessToken,UserId = user.Id};
    }
}