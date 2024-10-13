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

    public async Task<IEnumerable<Recipe>> GetMenuGenerationDataAsync(Guid userId, int mealsPerDay, int targetCalories, CancellationToken cancellationToken = default)
    {
        var allUserRecipes = await _dbContext.Recipes
            .Where(r => r.UserId == userId && !r.IsDeleted)
            .ToListAsync(cancellationToken);
        
        int averageCaloriesPerMeal = targetCalories / mealsPerDay;
        
        var suitableRecipes = allUserRecipes
            .Where(r => r.Calories >= averageCaloriesPerMeal * 0.8 && r.Calories <= averageCaloriesPerMeal * 1.2 && !r.IsDeleted)
            .ToList();
        
        if (suitableRecipes.Count < mealsPerDay)
        {
            var additionalRecipes = allUserRecipes
                .Except(suitableRecipes)
                .OrderBy(r => Math.Abs(r.Calories - averageCaloriesPerMeal))
                .Take(mealsPerDay - suitableRecipes.Count);

            suitableRecipes.AddRange(additionalRecipes);
        }
        
        if (suitableRecipes.Count > mealsPerDay)
        {
            suitableRecipes = suitableRecipes
                .OrderBy(x => Guid.NewGuid())
                .Take(mealsPerDay)
                .ToList();
        }

        return suitableRecipes;
    }

    public void Delete(Menu entity)
    {
        entity.IsDeleted = true;
        _dbContext.Menus.Update(entity);
    }
}