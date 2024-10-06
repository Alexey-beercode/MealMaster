using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces;
using MealMaster.DAL.Interfaces.Repositories;

namespace MealMaster.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly IAllergyRepository _allergyRepository;
        private readonly ICuisineTypeRepository _cuisineTypeRepository;
        private readonly IDietaryRestrictionRepository _dietaryRestrictionRepository;
        private readonly IMenuHistoryRepository _menuHistoryRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IRecipeRepository _recipeRepository;

        public UnitOfWork(ApplicationDbContext dbContext, 
                          IUserRepository userRepository, 
                          IAllergyRepository allergyRepository, 
                          ICuisineTypeRepository cuisineTypeRepository, 
                          IDietaryRestrictionRepository dietaryRestrictionRepository, 
                          IMenuHistoryRepository menuHistoryRepository, 
                          IMenuRepository menuRepository, 
                          IRecipeRepository recipeRepository)

        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _allergyRepository = allergyRepository;
            _cuisineTypeRepository = cuisineTypeRepository;
            _dietaryRestrictionRepository = dietaryRestrictionRepository;
            _menuHistoryRepository = menuHistoryRepository;
            _menuRepository = menuRepository;
            _recipeRepository = recipeRepository;
        }

        public IUserRepository Users => _userRepository;
        public IAllergyRepository Allergies => _allergyRepository;
        public ICuisineTypeRepository CuisineTypes => _cuisineTypeRepository;
        public IDietaryRestrictionRepository DietaryRestrictions => _dietaryRestrictionRepository; 
        public IMenuHistoryRepository MenuHistories => _menuHistoryRepository; 
        public IMenuRepository Menus => _menuRepository; 
        public IRecipeRepository Recipes => _recipeRepository; 


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}