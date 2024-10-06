using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces.Repositories;
using MealMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealMaster.DAL.Repositories;

public class CuisineTypeRepository:BaseRepository<CuisineType>,ICuisineTypeRepository
{
    public CuisineTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<CuisineType> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.CuisineTypes.FirstOrDefaultAsync(type => type.Name == name && !type.IsDeleted,cancellationToken);
    }

    public void Delete(CuisineType entity)
    {
        entity.IsDeleted = true;
        _dbContext.CuisineTypes.Update(entity);
    }
}