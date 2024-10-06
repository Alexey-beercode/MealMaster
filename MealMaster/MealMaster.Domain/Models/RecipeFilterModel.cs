namespace MealMaster.Domain.Models;

public class RecipeFilterModel
{
    public string SearchTerm { get; set; }
    public int? MinCalories { get; set; } 
    public int? MaxCalories { get; set; } 
    public int? MinPreparationTime { get; set; } 
    public int? MaxPreparationTime { get; set; } 
    public Guid? CuisineTypeId { get; set; }
}