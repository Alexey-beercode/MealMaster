namespace MealMaster.BLL.DTOs.Response.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}