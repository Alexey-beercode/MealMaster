using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IMenuRepository : IBaseRepository<Menu>
{
    Task<IEnumerable<Menu>> GetMenusByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<MenuGenerationDataModel> GetMenuGenerationDataAsync(Guid userId, int mealsPerDay, int targetCalories,
        CancellationToken cancellationToken = default);
    void Delete(Menu entity);
}