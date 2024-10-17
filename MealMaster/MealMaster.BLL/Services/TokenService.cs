using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MealMaster.BLL.Interfaces;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MealMaster.BLL.Services;

public class TokenService:ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateAccessToken(User user)
    {
        var claims = CreateClaims(user);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expire"])),
            signingCredentials: credentials
        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(jwtToken);
    }

    private List<Claim> CreateClaims(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
        };
        
        return claims;
    }
    
    public TokenModel GenerateRefreshToken()
    {
        int size = 64;
        var randomNumber = new byte[size];
        var refreshToken = string.Empty;
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            refreshToken=Convert.ToBase64String(randomNumber);
        }
        
        var expireTime= DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenExpirationDays").Get<int>());

        return new TokenModel()
            { RefreshToken = refreshToken, RefreshTokenExireTime =expireTime };
    }
}