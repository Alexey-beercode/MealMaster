using MealMaster.DAL.Infrastructure.Database;
using MealMaster.DAL.Interfaces;
using MealMaster.DAL.Interfaces.Repositories;

namespace MealMaster.DAL.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly ICuisineTypeRepository _cuisineTypeRepository;
        private readonly IMenuHistoryRepository _menuHistoryRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(ApplicationDbContext dbContext, 
                          IUserRepository userRepository, 
                          ICuisineTypeRepository cuisineTypeRepository, 
                          IMenuHistoryRepository menuHistoryRepository, 
                          IMenuRepository menuRepository, 
                          IRecipeRepository recipeRepository, IProductRepository productRepository)

        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _cuisineTypeRepository = cuisineTypeRepository;
            _menuHistoryRepository = menuHistoryRepository;
            _menuRepository = menuRepository;
            _recipeRepository = recipeRepository;
            _productRepository = productRepository;
        }

        public IUserRepository Users => _userRepository;
        public ICuisineTypeRepository CuisineTypes => _cuisineTypeRepository;
        public IMenuHistoryRepository MenuHistories => _menuHistoryRepository; 
        public IMenuRepository Menus => _menuRepository; 
        public IRecipeRepository Recipes => _recipeRepository;
        public IProductRepository Products => _productRepository;


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}