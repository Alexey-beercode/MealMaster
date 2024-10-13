using MealMaster.BLL.DTOs.Response.Recipe;

namespace MealMaster.BLL.DTOs.Response.MenuItem;

public class MenuItemResponseDto
{
    public int PortionSize { get; set; }
    public RecipeResponseDto RecipeResponseDto { get; set; }
}