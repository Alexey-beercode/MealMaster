using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class RecipeProduct:BaseEntity
{
    public Guid RecipeId { get; set; }
    public Guid ProductId { get; set; }
}