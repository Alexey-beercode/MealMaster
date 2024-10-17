using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class MenuHistoryRepository:BaseRepository<MenuHistory>,IMenuHistoryRepository
{
    public MenuHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<MenuHistory>> GetMenuHistoryByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.MenuHistories
            .Where(history => history.UserId == userId && !history.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public void Delete(MenuHistory entity)
    {
        entity.IsDeleted = true;
        _dbContext.MenuHistories.Update(entity);
    }

}