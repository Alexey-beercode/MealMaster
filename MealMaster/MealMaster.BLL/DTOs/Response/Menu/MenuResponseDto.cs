using MealMaster.BLL.DTOs.Request.MenuItem;
using MealMaster.BLL.DTOs.Response.MenuItem;

namespace MealMaster.BLL.DTOs.Response.Menu;

public class MenuResponseDto
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public int TotalCalories { get; set; }
    public int MealCount { get; set; }
    public List<MenuItemResponseDto> MenuItems { get; set; }
}