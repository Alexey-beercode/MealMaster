using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.DAL.Interfaces.Specifications;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
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

    public async Task<IEnumerable<Recipe>> SearchRecipesAsync(ISpecification<Recipe> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    private IQueryable<Recipe> ApplySpecification(ISpecification<Recipe> spec)
    {
        var query = _dbContext.Recipes.AsQueryable();
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        query = spec.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }

    public async Task DeleteAsync(Recipe entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _dbContext.Recipes.Update(entity);

        await _dbContext.MenuItems.Where(item => item.RecipeId == entity.Id && !item.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(item => item.IsDeleted, true), cancellationToken);

        await _dbContext.RecipeProducts.Where(rp => rp.RecipeId == entity.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<IEnumerable<RecipeProduct>> GetRecipeProductsAsync(Guid recipeId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.RecipeProducts
            .Where(rp => rp.RecipeId == recipeId && !rp.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task AddRecipeProductAsync(RecipeProduct recipeProduct, CancellationToken cancellationToken = default)
    {
        await _dbContext.RecipeProducts.AddAsync(recipeProduct, cancellationToken);
    }

    public async Task RemoveRecipeProductAsync(RecipeProduct recipeProduct, CancellationToken cancellationToken = default)
    {
        _dbContext.RecipeProducts.Remove(recipeProduct);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<Recipe>> GetByMenuIdAsync(Guid menuId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Recipes
            .Join(_dbContext.MenuItems,
                recipe => recipe.Id,
                menuItem => menuItem.RecipeId,
                (recipe, menuItem) => new { Recipe = recipe, MenuItem = menuItem })
            .Where(x => x.MenuItem.MenuId == menuId)
            .Select(x => x.Recipe)
            .ToListAsync(cancellationToken);
    }

    public Task<Recipe> GetByMultipleParamsAsync(string name, Guid userId, string description,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Recipes.FirstOrDefaultAsync(recipe =>
            !recipe.IsDeleted && recipe.UserId == userId && recipe.Description == description && recipe.Name == name,cancellationToken);
    }

    public Task<RecipeProduct> GetRecipeProductAsync(Guid recipeId, Guid productId, CancellationToken cancellationToken = default)
    {
        return _dbContext.RecipeProducts.FirstOrDefaultAsync(product =>
            product.RecipeId == recipeId && product.ProductId == productId && !product.IsDeleted);
    }
}