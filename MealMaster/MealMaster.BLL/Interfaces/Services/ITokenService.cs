using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.BLL.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    TokenModel GenerateRefreshToken();
}