namespace MealMaster.BLL.DTOs.Request.Menu;

public class GenerateMenuDto
{
    public Guid UserId { get; set; }
    public int RecipeCount { get; set; }
    public int Calories { get; set; }
}