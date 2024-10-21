using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.Auth;
using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto, CancellationToken cancellationToken)
        {
            var result = await _authService.AuthenticateAsync(loginDto, cancellationToken);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register([FromBody] RegisterDto registerDto, CancellationToken cancellationToken)
        {
            var result = await _authService.RegisterAsync(registerDto, cancellationToken);
            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthResponseDto>> RefreshToken([FromBody] string refreshToken, CancellationToken cancellationToken)
        {
            var result = await _authService.RefreshTokenAsync(refreshToken, cancellationToken);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] string refreshToken, CancellationToken cancellationToken)
        {
            await _authService.LogoutAsync(refreshToken, cancellationToken);
            return NoContent();
        }
    }
}