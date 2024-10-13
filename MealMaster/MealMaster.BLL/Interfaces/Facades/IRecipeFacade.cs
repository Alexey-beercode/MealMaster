using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Interfaces.Facades;

public interface IRecipeFacade
{
    Task<RecipeResponseDto> CreateFullRecipeDtoAsync(Recipe recipe, CancellationToken cancellationToken);
}