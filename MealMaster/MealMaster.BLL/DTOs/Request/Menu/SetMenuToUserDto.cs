namespace MealMaster.BLL.DTOs.Request.Menu;

public class SetMenuToUserDto
{
    public Guid MenuId { get; set; }
    public Guid UserId { get; set; }
}