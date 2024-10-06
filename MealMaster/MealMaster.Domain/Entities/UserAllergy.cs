using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class UserAllergy : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid AllergyId { get; set; }
}