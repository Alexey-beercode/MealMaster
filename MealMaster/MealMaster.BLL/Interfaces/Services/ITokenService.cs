using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
}