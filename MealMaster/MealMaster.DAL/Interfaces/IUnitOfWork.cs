using MealMaster.DAL.Interfaces.Repositories;

namespace MealMaster.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IUserRepository Users { get; }
        IAllergyRepository Allergies { get; }
        ICuisineTypeRepository CuisineTypes { get; }
        IDietaryRestrictionRepository DietaryRestrictions { get; }
        IMenuHistoryRepository MenuHistories { get; }
        IMenuRepository Menus { get; }
        IRecipeRepository Recipes { get; }
    }
}