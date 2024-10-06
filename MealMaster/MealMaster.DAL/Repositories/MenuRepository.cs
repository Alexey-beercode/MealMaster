using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class MenuRepository:BaseRepository<Menu>,IMenuRepository
{
    public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Menu>> GetMenusByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Menus.Where(menu => menu.UserId == userId && !menu.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public Task<MenuGenerationDataModel> GetMenuGenerationDataAsync(Guid userId, int mealsPerDay, int targetCalories,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Delete(Menu entity)
    {
        entity.IsDeleted = true;
        _dbContext.Menus.Update(entity);
    }
}