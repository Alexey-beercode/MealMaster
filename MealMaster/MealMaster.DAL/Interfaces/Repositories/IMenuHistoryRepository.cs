using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IMenuHistoryRepository : IBaseRepository<MenuHistory>
{
    Task<IEnumerable<MenuHistory>> GetMenuHistoryByUserIdAsync(Guid userId, CancellationToken cancellationToken = default); // История меню пользователя
}