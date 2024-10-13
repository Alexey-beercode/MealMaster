using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IDietaryRestrictionRepository:IBaseRepository<DietaryRestriction>
{
    Task<DietaryRestriction> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    Task<IEnumerable<DietaryRestriction>> GetUserRestrictionsAsync(Guid userId,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(DietaryRestriction entity, CancellationToken cancellationToken = default);
}