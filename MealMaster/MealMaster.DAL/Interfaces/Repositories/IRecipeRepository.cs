using System.Collections;
using MealMaster.DAL.Interfaces.Specifications;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;
using MealMaster.DAL.Specifications;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<IEnumerable<Recipe>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> SearchRecipesAsync(ISpecification<Recipe> specification, CancellationToken cancellationToken = default);
    Task DeleteAsync(Recipe entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<RecipeProduct>> GetRecipeProductsAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task AddRecipeProductAsync(RecipeProduct recipeProduct, CancellationToken cancellationToken = default);
    Task RemoveRecipeProductAsync(RecipeProduct recipeProduct, CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> GetByMenuIdAsync(Guid menuId, CancellationToken cancellationToken = default);

    Task<Recipe> GetByMultipleParamsAsync(string name, Guid userId, string description,
        CancellationToken cancellationToken = default);

    Task<RecipeProduct> GetRecipeProductAsync(Guid recipeId, Guid productId,
        CancellationToken cancellationToken = default);
}