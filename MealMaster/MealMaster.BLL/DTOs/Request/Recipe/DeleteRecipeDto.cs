namespace MealMaster.BLL.DTOs.Request.Recipe;

public class DeleteRecipeDto
{
    public Guid UserId { get; set; }
    public Guid RecipeId { get; set; }
}