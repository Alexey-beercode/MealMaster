using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Recipe;

namespace MealMaster.BLL.Interfaces.Services;

public interface IMenuService
{
    Task<IEnumerable<RecipeResponseDto>> GenerateMenuAsync(GenerateMenuDto generateMenuDto, CancellationToken cancellationToken = default);
}