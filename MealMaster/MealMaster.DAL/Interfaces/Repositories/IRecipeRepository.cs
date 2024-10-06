using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IRecipeRepository : IBaseRepository<Recipe>
{
    Task<IEnumerable<Recipe>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> SearchRecipesAsync(string searchTerm, int? minCalories, int? maxCalories, int? minPreparationTime, int? maxPreparationTime, Guid? cuisineTypeId, CancellationToken cancellationToken = default); // Поиск и фильтрация
}