using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IAllergyRepository : IBaseRepository<Allergy>
{
    Task<IEnumerable<Allergy>> GetUserAllergiesAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddUserAllergyAsync(UserAllergy userAllergy, CancellationToken cancellationToken = default);
    Task RemoveUserAllergyAsync(Guid userId, Guid allergyId, CancellationToken cancellationToken = default);
}