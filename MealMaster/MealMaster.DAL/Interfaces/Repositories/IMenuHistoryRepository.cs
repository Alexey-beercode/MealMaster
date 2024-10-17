using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IMenuHistoryRepository : IBaseRepository<MenuHistory>
{
    Task<IEnumerable<MenuHistory>> GetMenuHistoryByUserIdAsync(Guid userId, CancellationToken cancellationToken = default); 
    void Delete(MenuHistory entity);
}