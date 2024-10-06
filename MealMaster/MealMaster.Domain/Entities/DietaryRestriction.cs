using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class DietaryRestriction : BaseEntity
{
    public string Name { get; set; }
}