namespace MealMaster.Domain.Models;

public class UserPreferences
{
    public IEnumerable<Guid> PreferredProductIds { get; set; }
    public IEnumerable<Guid> DietaryRestrictionIds { get; set; }
}