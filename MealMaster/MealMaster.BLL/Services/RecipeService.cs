using AutoMapper;
using MealMaster.BLL.DTOs.Request.Recipe;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Interfaces.Facades;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;
using MealMaster.DAL.Specifications;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.BLL.Services;

public class RecipeService:IRecipeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeFacade _recipeFacade;

    public RecipeService(IMapper mapper, IUnitOfWork unitOfWork, IRecipeFacade recipeFacade)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _recipeFacade = recipeFacade;
    }

    public async Task CreateAsync(CreateRecipeDto createRecipeDto, CancellationToken cancellationToken = default)
    {
        var recipe = _mapper.Map<Recipe>(createRecipeDto);
        recipe.CreatedDate=DateTime.UtcNow;
        
        await _unitOfWork.Recipes.CreateAsync(recipe, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var newRecipe = await _unitOfWork.Recipes.GetByMultipleParamsAsync(createRecipeDto.Name, createRecipeDto.UserId,
            createRecipeDto.Description, cancellationToken);

        foreach (var productId in createRecipeDto.ProductIds)
        {
            await _unitOfWork.Recipes.AddRecipeProductAsync(
                new RecipeProduct() { ProductId = productId, RecipeId = newRecipe.Id }, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task ProductToRecipeOperationAsync(ProductToRecipeOperationDto productToRecipeOperationDto,
        CancellationToken cancellationToken = default)
    {
        var recipeId = productToRecipeOperationDto.RecipeId;
        var productId = productToRecipeOperationDto.ProductId;
        
        var recipe = await _unitOfWork.Recipes.GetByIdAsync(recipeId, cancellationToken);

        if (recipe is null)
        {
            throw new EntityNotFoundException("Recipe", recipeId);
        }

        var product = await _unitOfWork.Products.GetByIdAsync(productId);

        if (product is null)
        {
            throw new EntityNotFoundException("Product", productId);
        }
        
        if (productToRecipeOperationDto.IsAdding)
        {
            await _unitOfWork.Recipes.AddRecipeProductAsync(new RecipeProduct()
                { RecipeId = recipeId, ProductId = productId });
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        else
        {
            var recipeProduct = await _unitOfWork.Recipes.GetRecipeProductAsync(recipeId, productId, cancellationToken);

            if (recipeProduct is null)
            {
                throw new EntityNotFoundException("Product in recipe not found");
            }

            await _unitOfWork.Recipes.RemoveRecipeProductAsync(recipeProduct, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task<IEnumerable<RecipeResponseDto>> GetByFilterAsync(RecipeFilterDto recipeFilterDto, CancellationToken cancellationToken = default)
    {
        var filterModel = _mapper.Map<RecipeFilterModel>(recipeFilterDto); 

        var specification = new RecipeFilterSpecification(filterModel);

        var recipes = await _unitOfWork.Recipes.SearchRecipesAsync(specification, cancellationToken);

        var recipeDtos = new List<RecipeResponseDto>();

        foreach (var recipe in recipes)
        {
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            recipeDtos.Add(recipeDto);
        }

        return recipeDtos;
    }

    public async Task UpdateAsync(UpdateRecipeDto updateRecipeDto, CancellationToken cancellationToken = default)
    {
        var recipe = await _unitOfWork.Recipes.GetByIdAsync(updateRecipeDto.Id, cancellationToken);

        if (recipe is null)
        {
            throw new EntityNotFoundException("Recipe", updateRecipeDto.Id);
        }

        _mapper.Map(updateRecipeDto, recipe);
        
        _unitOfWork.Recipes.Update(recipe);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteRecipeDto deleteRecipeDto, CancellationToken cancellationToken = default)
    {
        var recipe = await _unitOfWork.Recipes.GetByIdAsync(deleteRecipeDto.RecipeId, cancellationToken);

        if (recipe is null)
        {
            throw new EntityNotFoundException("Recipe", deleteRecipeDto.RecipeId);
        }

        if (recipe.UserId!=deleteRecipeDto.UserId)
        {
            throw new InvalidOperationException("This user cant delete recipe");
        }

        await _unitOfWork.Recipes.DeleteAsync(recipe, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<RecipeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var recipes = await _unitOfWork.Recipes.GetAllAsync(cancellationToken);
        var recipesDtos = new List<RecipeResponseDto>();
        foreach (var recipe in recipes)
        {
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            recipesDtos.Add(recipeDto);
        }

        return recipesDtos;
    }

    public async Task<RecipeResponseDto> GetByIdAsync(Guid recipeId, CancellationToken cancellationToken = default)
    {
        var recipe = await _unitOfWork.Recipes.GetByIdAsync(recipeId, cancellationToken);

        if (recipe is null)
        {
            throw new EntityNotFoundException("Recipe", recipeId);
        }

        return await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
    }

    public async Task<IEnumerable<RecipeResponseDto>> GetRecipesByUserPreferencesAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var preferences = await GetUserPreferencesAsync(userId, cancellationToken);
        var allRecipes = await _unitOfWork.Recipes.GetAllAsync(cancellationToken);
        var recipes = FilterRecipesByPreferences(allRecipes, preferences);

        var recipesDtos = new List<RecipeResponseDto>();
        foreach (var recipe in recipes)
        {
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            recipesDtos.Add(recipeDto);
        }

        return recipesDtos;
    }
    
    public async Task<UserPreferences> GetUserPreferencesAsync(Guid userId, CancellationToken cancellationToken = default)
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

    public IEnumerable<Recipe> FilterRecipesByPreferences(IEnumerable<Recipe> recipes, UserPreferences preferences)
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
}