using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class Allergy : BaseEntity
{
    public string Name { get; set; }
}