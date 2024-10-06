using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IDietaryRestrictionRepository : IBaseRepository<DietaryRestriction>
{
    Task<IEnumerable<DietaryRestriction>> GetUserRestrictionsAsync(Guid userId, CancellationToken cancellationToken = default); // Получение ограничений пользователя
    Task AddUserRestrictionAsync(UserRestriction userRestriction, CancellationToken cancellationToken = default);
    Task RemoveUserRestrictionAsync(Guid userId, Guid restrictionId, CancellationToken cancellationToken = default);
}