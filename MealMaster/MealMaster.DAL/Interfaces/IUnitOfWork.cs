using MealMaster.DAL.Interfaces.Repositories;

namespace MealMaster.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IUserRepository Users { get; }
        ICuisineTypeRepository CuisineTypes { get; }
        IMenuHistoryRepository MenuHistories { get; }
        IMenuRepository Menus { get; }
        IRecipeRepository Recipes { get; }
        IProductRepository Products { get; }
        IDietaryRestrictionRepository DietaryRestrictions { get; }
    }
}