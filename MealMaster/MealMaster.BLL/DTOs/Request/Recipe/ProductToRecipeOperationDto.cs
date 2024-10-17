namespace MealMaster.BLL.DTOs.Request.Recipe;

public class ProductToRecipeOperationDto
{
    public Guid UserId { get; set; }
    public Guid RecipeId { get; set; }
    public Guid ProductId { get; set; }
    public bool IsAdding { get; set; }
}