using MealMaster.BLL.DTOs.Request.MenuItem;

namespace MealMaster.BLL.DTOs.Request.Menu;

public class CreateMenuDto
{
    public List<MenuItemDto> MenuItems { get; set; }
    public Guid UserId { get; set; }
    public int TotalCalories { get; set; }
}