namespace MealMaster.BLL.DTOs.Response.Menu;

public class MenuHistoryResponseDto
{
    public DateTime CreatedDate { get; set; }
    public MenuResponseDto Menu { get; set; }
    public Guid UserId { get; set; }
}