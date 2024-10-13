namespace MealMaster.BLL.DTOs.Response.Auth;

public class AuthResponseDto
{
    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }
    public Guid UserId { get; set; }
}