using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Name == name && !p.IsDeleted, cancellationToken);
    }
    
    public async Task<IEnumerable<Product>> GetMostFrequentProductsForUserAsync(Guid userId, int count, CancellationToken cancellationToken = default)
    {
        var productIds = await _dbContext.Menus
            .Where(m => m.UserId == userId && !m.IsDeleted)
            .Join(_dbContext.MenuItems, m => m.Id, mi => mi.MenuId, (m, mi) => mi)
            .Join(_dbContext.RecipeProducts, mi => mi.RecipeId, rp => rp.RecipeId, (mi, rp) => rp.ProductId)
            .GroupBy(productId => productId)
            .OrderByDescending(g => g.Count())
            .Take(count)
            .Select(g => g.Key)
            .ToListAsync(cancellationToken);

        return await _dbSet
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }
}