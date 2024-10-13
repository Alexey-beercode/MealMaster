using AutoMapper;
using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Facades;
using MealMaster.BLL.Interfaces;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.BLL.Services;

public class MenuService : IMenuService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly RecipeFacade _recipeFacade;

    public MenuService(IUnitOfWork unitOfWork, IMapper mapper, RecipeFacade recipeFacade)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _recipeFacade = recipeFacade;
    }

    public async Task<IEnumerable<RecipeResponseDto>> GenerateMenuAsync(GenerateMenuDto generateMenuDto, CancellationToken cancellationToken = default)
    {
        var allUserRecipes = await _unitOfWork.Menus.GetMenuGenerationDataAsync(generateMenuDto.UserId, generateMenuDto.RecipeCount, generateMenuDto.Calories, cancellationToken);
        var userPreferences = await GetUserPreferencesAsync(generateMenuDto.UserId, cancellationToken);

        int averageCaloriesPerMeal = generateMenuDto.Calories / generateMenuDto.RecipeCount;

        var suitableRecipes = FilterRecipesByPreferences(allUserRecipes, userPreferences)
            .Where(r => IsRecipeSuitable(r, averageCaloriesPerMeal))
            .ToList();

        suitableRecipes = AdjustRecipeCount(suitableRecipes, allUserRecipes, generateMenuDto.RecipeCount, averageCaloriesPerMeal);

        var recipeResponseDtos = new List<RecipeResponseDto>();
        foreach (var recipe in suitableRecipes)
        {
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            recipeResponseDtos.Add(recipeDto);
        }

        return recipeResponseDtos;
    }

    private async Task<UserPreferences> GetUserPreferencesAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(userId, cancellationToken);

        if (user == null)
        {
            throw new EntityNotFoundException("User", userId);
        }

        var mostFrequentProducts = await _unitOfWork.Products.GetMostFrequentProductsForUserAsync(userId, 10, cancellationToken);
        var userRestrictions = await _unitOfWork.DietaryRestrictions.GetUserRestrictionsAsync(userId, cancellationToken);

        return new UserPreferences
        {
            PreferredProductIds = mostFrequentProducts.Select(p => p.Id),
            DietaryRestrictionIds = userRestrictions.Select(ur => ur.Id)
        };
    }

    private IEnumerable<Recipe> FilterRecipesByPreferences(IEnumerable<Recipe> recipes, UserPreferences preferences)
    {
        return recipes.Where(r => 
        {
            var recipeProducts = _unitOfWork.Recipes.GetRecipeProductsAsync(r.Id).Result;
            return (preferences.PreferredProductIds == null || 
                    !preferences.PreferredProductIds.Any() ||
                    preferences.PreferredProductIds.Intersect(recipeProducts.Select(rp => rp.ProductId)).Any()) &&
                   (preferences.DietaryRestrictionIds == null || 
                    !preferences.DietaryRestrictionIds.Any() ||
                    preferences.DietaryRestrictionIds.Contains(r.RestrictionId));
        });
    }

    private bool IsRecipeSuitable(Recipe recipe, int averageCaloriesPerMeal)
    {
        return recipe.Calories >= averageCaloriesPerMeal * 0.8 && recipe.Calories <= averageCaloriesPerMeal * 1.2;
    }

    private List<Recipe> AdjustRecipeCount(List<Recipe> suitableRecipes, IEnumerable<Recipe> allRecipes, int mealsPerDay, int averageCaloriesPerMeal)
    {
        if (suitableRecipes.Count < mealsPerDay)
        {
            var additionalRecipes = allRecipes
                .Except(suitableRecipes)
                .OrderBy(r => Math.Abs(r.Calories - averageCaloriesPerMeal))
                .Take(mealsPerDay - suitableRecipes.Count);

            suitableRecipes.AddRange(additionalRecipes);
        }

        if (suitableRecipes.Count > mealsPerDay)
        {
            suitableRecipes = suitableRecipes
                .OrderBy(x => Guid.NewGuid())
                .Take(mealsPerDay)
                .ToList();
        }

        return suitableRecipes;
    }
}