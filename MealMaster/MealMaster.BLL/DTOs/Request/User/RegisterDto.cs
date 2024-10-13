namespace MealMaster.BLL.DTOs.Request.User;

public class RegisterDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Guid> DietaryRestrictionsIds { get; set; }
}