using MealMaster.BLL.DTOs.Response.CuisineType;
using MealMaster.BLL.DTOs.Response.DietaryRestriction;
using MealMaster.BLL.DTOs.Response.Product;

namespace MealMaster.BLL.DTOs.Response.Recipe;

public class RecipeResponseDto
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Calories { get; set; }
    public int PreparationTime { get; set; }
    public CuisineTypeResponseDto CuisineType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DietaryRestrictionResponseDto Restriction { get; set; }
    public List<ProductResponseDto> Products { get; set; }
}