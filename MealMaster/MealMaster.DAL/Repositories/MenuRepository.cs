﻿using MealMaster.DAL.Infrastructure.Database;
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

    public async Task<IEnumerable<MenuItem>> GetMenuItemsByRecipeIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.MenuItems.Where(item => item.RecipeId == recipeId && !item.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItemsByMenuId(Guid menuId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.MenuItems.Where(item => item.MenuId == menuId && !item.IsDeleted).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Recipe>> GetMenuGenerationDataAsync(Guid userId, int mealsPerDay, int targetCalories, CancellationToken cancellationToken = default)
    {
        var allUserRecipes = await _dbContext.Recipes
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

    public async Task AddMenuToUserAsync(MenuHistory menuHistory, CancellationToken cancellationToken = default)
    {
        await _dbContext.MenuHistories.AddAsync(menuHistory, cancellationToken);
    }

    public void Delete(Menu entity)
    {
        entity.IsDeleted = true;
        _dbContext.Menus.Update(entity);
    }

    public Task<Menu> GetByDateAsync(DateTime date, CancellationToken cancellationToken = default)
    {
        return _dbContext.Menus.FirstOrDefaultAsync(menu => menu.Date == date && !menu.IsDeleted, cancellationToken);
    }

    public async Task CreateMenuItemAsync(MenuItem menuItem, CancellationToken cancellationToken = default)
    {
        await _dbContext.MenuItems.AddAsync(menuItem, cancellationToken);
    }
}