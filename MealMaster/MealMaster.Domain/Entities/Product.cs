using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class Product:BaseEntity
{
    public string Name { get; set; }
}