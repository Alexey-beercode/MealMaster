using AutoMapper;
using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.User;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Interfaces;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;

namespace MealMaster.BLL.Services;

public class UserService:IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _unitOfWork.Users.GetAllAsync(cancellationToken);

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<UserResponseDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException("User", userId);
        }
        
        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<UserResponseDto> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByNameAsync(userName, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException($"User with username : {userName} are not found");
        }
        
        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);
        if (user is null)
        {
            throw new EntityNotFoundException("User", userId);
        }

        await _unitOfWork.Users.DeleteAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Guid userId, UpdateUserDto updateUserDto, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);

        if (user is null)
        {
            throw new EntityNotFoundException("User", userId);
        }

        if (updateUserDto.Age!=user.Age)
        {
            user.Age = updateUserDto.Age;
        }

        if (updateUserDto.Name!=user.Name)
        {
            user.Name = updateUserDto.Name;
        }

        _unitOfWork.Users.Update(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}