namespace MealMaster.BLL.DTOs.Request.Recipe;

public class UpdateRecipeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Calories { get; set; }
    public int PreparationTime { get; set; }
    public Guid CuisineTypeId { get; set; }
    public Guid RestrictionId { get; set; }
}