namespace MealMaster.BLL.DTOs.Request.Menu;

public class DeleteMenuDto
{
    public Guid UserId { get; set; }
    public Guid MenuId { get; set; }
}