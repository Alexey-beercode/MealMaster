using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class MenuItem : BaseEntity
{
    public Guid MenuId { get; set; }
    public Guid RecipeId { get; set; }
    public int PortionSize { get; set; }
}