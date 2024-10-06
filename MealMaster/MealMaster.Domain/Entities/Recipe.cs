using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class Recipe : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public int Calories { get; set; }
    public int PreparationTime { get; set; }
    public Guid CuisineTypeId { get; set; }
    public DateTime CreatedDate { get; set; }
}