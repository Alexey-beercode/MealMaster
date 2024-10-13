using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class UserRepository:BaseRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email && !user.IsDeleted,cancellationToken);
    }
    
    public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _dbSet.Update(entity);
        
        await _dbContext.UserRestrictions
            .Where(ur => ur.UserId == entity.Id && !ur.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(ur => ur.IsDeleted, true), cancellationToken);
        
        await _dbContext.Menus
            .Where(m => m.UserId == entity.Id && !m.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(m => m.IsDeleted, true), cancellationToken);
        
        await _dbContext.MenuHistories
            .Where(mh => mh.UserId == entity.Id && !mh.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(mh => mh.IsDeleted, true), cancellationToken);
        
        await _dbContext.Recipes
            .Where(r => r.UserId == entity.Id && !r.IsDeleted)
            .ExecuteUpdateAsync(s => s.SetProperty(r => r.IsDeleted, true), cancellationToken);
        
    }
}