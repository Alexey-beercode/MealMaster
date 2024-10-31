using MealMaster.Domain.Entities;

namespace MealMaster.DAL.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task DeleteAsync(User entity, CancellationToken cancellationToken = default);
    Task<User> GetByNameAsync(string userName, CancellationToken cancellationToken=default);
    Task<User> GetByRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task AddRestractionsToUser(List<DietaryRestriction> dietaryRestrictions, Guid userId,
        CancellationToken cancellationToken = default);
}