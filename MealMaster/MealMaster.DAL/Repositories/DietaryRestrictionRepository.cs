using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class DietaryRestrictionRepository:BaseRepository<DietaryRestriction>,IDietaryRestrictionRepository
{
    public DietaryRestrictionRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<DietaryRestriction>> GetUserRestrictionsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.DietaryRestrictions
            .Where(restriction => _dbContext.UserRestrictions
                .Any(ua => ua.UserId == userId && ua.RestrictionId == restriction.Id))
            .ToListAsync(cancellationToken);
    }
    
    public async Task DeleteAsync(DietaryRestriction entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _dbContext.DietaryRestrictions.Update(entity);
        
        await _dbContext.UserRestrictions
            .Where(restriction => restriction.RestrictionId == entity.Id && !restriction.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(ua => ua.IsDeleted, true), cancellationToken);
    }

    public Task<DietaryRestriction> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return _dbSet.FirstOrDefaultAsync(restriction => !restriction.IsDeleted && restriction.Name == name);
    }
}