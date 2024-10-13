namespace MealMaster.BLL.DTOs.Request.Recipe;

public class RecipeFilterDto
{
    public Guid UserId { get; set; }
    public string SearchTerm { get; set; }
    public int? MinCalories { get; set; } 
    public int? MaxCalories { get; set; } 
    public int? MinPreparationTime { get; set; } 
    public int? MaxPreparationTime { get; set; } 
    public Guid? CuisineTypeId { get; set; }
    public Guid? RestrictionId { get; set; }
}