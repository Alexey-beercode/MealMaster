using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Interfaces.Facades;

public interface IMenuFacade
{
    Task<MenuResponseDto> CreateFullMenuDtoAsync(Menu menu, CancellationToken cancellationToken=default);

    Task<MenuResponseDto> CreateFullMenyDtoFromRecipesAsync(List<RecipeResponseDto> recipeResponseDtos,Guid userId,int recipeCount,
        CancellationToken cancellationToken = default);
}