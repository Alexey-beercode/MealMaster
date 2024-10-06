using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<IEnumerable<Recipe>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> SearchRecipesAsync(RecipeFilterModel filterModel, CancellationToken cancellationToken = default);
    Task DeleteAsync(Recipe entity, CancellationToken cancellationToken = default);
}