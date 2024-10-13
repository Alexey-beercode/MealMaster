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
    public async Task<IEnumerable<RecipeRecommendation>> GetRecipeRecommendationsAsync(Guid userId, int count, CancellationToken cancellationToken = default)
    {
        var recommendations = await _dbContext.MenuHistories
            .Where(mh => mh.UserId == userId)
            .Join(_dbContext.Menus,
                mh => mh.MenuId,
                m => m.Id,
                (mh, m) => m.Id)
            .Join(_dbContext.MenuItems,
                menuId => menuId,
                mi => mi.MenuId,
                (menuId, mi) => mi)
            .GroupBy(mi => mi.RecipeId)
            .Select(g => new RecipeRecommendation
            {
                RecipeId = g.Key,
                RecipeName = _dbContext.Recipes.Where(r => r.Id == g.Key).Select(r => r.Name).FirstOrDefault(),
                UsageCount = g.Count()
            })
            .OrderByDescending(r => r.UsageCount)
            .Take(count)
            .ToListAsync(cancellationToken);

        return recommendations;
    }
}