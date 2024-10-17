using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.Auth;

namespace MealMaster.BLL.Interfaces.Services;

public interface IAuthService
{
    Task LogoutAsync(string refreshToken,CancellationToken cancellationToken=default);
    Task<AuthResponseDto> AuthenticateAsync(LoginDto loginDto,CancellationToken cancellationToken=default);
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerUserDto, CancellationToken cancellationToken = default);
    Task<AuthResponseDto> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
}