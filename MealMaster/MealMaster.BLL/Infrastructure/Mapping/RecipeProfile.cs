using AutoMapper;
using MealMaster.BLL.DTOs.Request.Recipe;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            // Маппинг Recipe -> RecipeResponseDto
            CreateMap<Recipe, RecipeResponseDto>();

            // Маппинг CreateRecipeDto -> Recipe
            CreateMap<CreateRecipeDto, Recipe>();

            // Маппинг UpdateRecipeDto -> Recipe
            CreateMap<UpdateRecipeDto, Recipe>();

            // Маппинг DeleteRecipeDto -> Recipe
            CreateMap<DeleteRecipeDto, Recipe>();

            // Маппинг ProductToRecipeOperationDto -> RecipeProduct
            CreateMap<ProductToRecipeOperationDto, RecipeProduct>();

            // Маппинг RecipeFilterDto -> RecipeFilterModel
            CreateMap<RecipeFilterDto, RecipeFilterModel>();
        }
    }
}