using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class Menu : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public int TotalCalories { get; set; }
    public int MealCount { get; set; }
}