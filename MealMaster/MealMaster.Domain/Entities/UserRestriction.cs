using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class UserRestriction : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RestrictionId { get; set; }
}