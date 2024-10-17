using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IMenuRepository : IBaseRepository<Menu>
{
    Task<IEnumerable<Menu>> GetMenusByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuItem>> GetMenuItemsByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuItem>> GetMenuItemsByMenuId(Guid menuId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Recipe>> GetMenuGenerationDataAsync(Guid userId, int mealsPerDay, int targetCalories,
        CancellationToken cancellationToken = default);
    Task AddMenuToUserAsync(MenuHistory menuHistory, CancellationToken cancellationToken = default);
    void Delete(Menu entity);
    Task<Menu> GetByDateAsync(DateTime date, CancellationToken cancellationToken = default);
    Task CreateMenuItemAsync(MenuItem menuItem, CancellationToken cancellationToken = default);
}