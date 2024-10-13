namespace MealMaster.Domain.Models;


public class RecipeRecommendation
{
    public Guid RecipeId { get; set; }
    public string RecipeName { get; set; }
    public int UsageCount { get; set; }
}