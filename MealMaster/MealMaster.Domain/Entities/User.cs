using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class User:BaseEntity
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}