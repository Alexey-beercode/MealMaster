using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class AllergyRepository:BaseRepository<Allergy>,IAllergyRepository
{
    public AllergyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Allergy>> GetUserAllergiesAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Allergies
            .Where(a => _dbContext.UserAllergies
                .Any(ua => ua.UserId == userId && ua.AllergyId == a.Id && !ua.IsDeleted))
            .ToListAsync(cancellationToken);
    }

    public async Task DeleteAsync(Allergy entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _dbSet.Update(entity);
        
        await _dbContext.UserAllergies
            .Where(ua => ua.AllergyId == entity.Id && !ua.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(ua => ua.IsDeleted, true), cancellationToken);
    }
}