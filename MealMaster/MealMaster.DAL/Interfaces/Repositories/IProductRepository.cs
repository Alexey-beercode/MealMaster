using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken = default); 
}