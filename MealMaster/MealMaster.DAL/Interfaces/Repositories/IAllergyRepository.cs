using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IAllergyRepository : IBaseRepository<Allergy>
{
    Task<IEnumerable<Allergy>> GetUserAllergiesAsync(Guid userId, CancellationToken cancellationToken = default);
    Task DeleteAsync(Allergy entity, CancellationToken cancellationToken = default);
}