using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<IEnumerable<Product>> GetMostFrequentProductsForUserAsync(Guid userId, int count, CancellationToken cancellationToken = default);
    Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken = default); 
}