using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class RecipeRepository:BaseRepository<Recipe>,IRecipeRepository
{
    public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Recipe>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Recipes
            .Where(recipe => recipe.UserId == userId && !recipe.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Recipe>> SearchRecipesAsync(RecipeFilterModel filterModel, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Recipes.AsQueryable();
        
        if (!string.IsNullOrEmpty(filterModel.SearchTerm))
        {
            query = query.Where(r => r.Name.Contains(filterModel.SearchTerm) || r.Description.Contains(filterModel.SearchTerm));
        }

        if (filterModel.MinCalories.HasValue)
        {
            query = query.Where(r => r.Calories >= filterModel.MinCalories.Value);
        }

        if (filterModel.MaxCalories.HasValue)
        {
            query = query.Where(r => r.Calories <= filterModel.MaxCalories.Value);
        }

        if (filterModel.MinPreparationTime.HasValue)
        {
            query = query.Where(r => r.PreparationTime >= filterModel.MinPreparationTime.Value);
        }

        if (filterModel.MaxPreparationTime.HasValue)
        {
            query = query.Where(r => r.PreparationTime <= filterModel.MaxPreparationTime.Value);
        }

        if (filterModel.CuisineTypeId.HasValue)
        {
            query = query.Where(r => r.CuisineTypeId == filterModel.CuisineTypeId.Value);
        }


        return await query.ToListAsync(cancellationToken);
    }

    public async Task DeleteAsync(Recipe entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _dbContext.Recipes.Update(entity);

        await _dbContext.MenuItems.Where(item => item.RecipeId == entity.Id && !item.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(item => item.IsDeleted, true),cancellationToken);
    }
}