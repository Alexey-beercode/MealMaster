using MealMaster.Domain.Interfaces;

namespace MealMaster.Domain.Entities;

public class MenuHistory : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid MenuId { get; set; }
    public DateTime CreatedDate { get; set; }
}