using AutoMapper;
using MealMaster.BLL.DTOs.Response.CuisineType;
using MealMaster.BLL.DTOs.Response.DietaryRestriction;
using MealMaster.BLL.DTOs.Response.Product;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.DAL.Interfaces;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Facades;

public class RecipeFacade
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecipeFacade(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RecipeResponseDto> CreateFullRecipeDtoAsync(Recipe recipe, CancellationToken cancellationToken)
    {
        var recipeDto = _mapper.Map<RecipeResponseDto>(recipe);
        
        var cuisineType = await _unitOfWork.CuisineTypes.GetByIdAsync(recipe.CuisineTypeId, cancellationToken);
        var restraction = await _unitOfWork.DietaryRestrictions.GetByIdAsync(recipe.RestrictionId, cancellationToken);
        
        var recipeProducts = await _unitOfWork.Recipes.GetRecipeProductsAsync(recipe.Id, cancellationToken);
        var productIds = recipeProducts.Select(rp => rp.ProductId);
        var products = new List<Product>();
        foreach (var productId in productIds)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productId, cancellationToken);
            products.Add(product);
        }

        recipeDto.CuisineType = _mapper.Map<CuisineTypeResponseDto>(cuisineType);
        recipeDto.Restriction = _mapper.Map<DietaryRestrictionResponseDto>(restraction);
        recipeDto.Products = _mapper.Map<List<ProductResponseDto>>(products);

        return recipeDto;
    }
}