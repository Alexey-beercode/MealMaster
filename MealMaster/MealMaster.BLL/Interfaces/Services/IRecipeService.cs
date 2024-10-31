using MealMaster.BLL.DTOs.Request.Recipe;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.BLL.Interfaces.Services;

public interface IRecipeService
{
    Task CreateAsync(CreateRecipeDto createRecipeDto, CancellationToken cancellationToken = default);
    Task ProductToRecipeOperationAsync(ProductToRecipeOperationDto productToRecipeOperationDto,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<RecipeResponseDto>> GetByFilterAsync(RecipeFilterDto recipeFilterDto,
        CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateRecipeDto updateRecipeDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(DeleteRecipeDto deleteRecipeDto, CancellationToken cancellationToken = default);
    Task<IEnumerable<RecipeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<RecipeResponseDto> GetByIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task<UserPreferences> GetUserPreferencesAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<IEnumerable<RecipeResponseDto>> GetRecipesByUserPreferencesAsync(Guid userId,
        CancellationToken cancellationToken = default);

    IEnumerable<Recipe> FilterRecipesByPreferences(IEnumerable<Recipe> recipes, UserPreferences preferences);
}