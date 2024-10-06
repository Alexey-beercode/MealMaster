using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface ICuisineTypeRepository : IBaseRepository<CuisineType>
{
    Task<CuisineType> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}