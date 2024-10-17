using MealMaster.Domain.Entities;

namespace MealMaster.Domain.Models;


public class RecipeRecommendation
{
    public Recipe Recipe { get; set; }
    public int PortionSize { get; set; }
}