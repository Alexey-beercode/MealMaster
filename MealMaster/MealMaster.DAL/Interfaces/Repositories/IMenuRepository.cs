using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IMenuRepository : IBaseRepository<Menu>
{
    Task<IEnumerable<Menu>> GetMenusByUserIdAsync(Guid userId, CancellationToken cancellationToken = default); // Получение меню пользователя
    Task<Menu> GenerateMenuAsync(Guid userId, int mealsPerDay, int targetCalories, CancellationToken cancellationToken = default); // Генерация меню
}