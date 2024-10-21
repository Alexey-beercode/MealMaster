using FluentValidation;
using MealMaster.BLL.DTOs.Request.MenuItem;

namespace MealMaster.BLL.Infrastructure.Validators.MenuItem;


public class MenuItemDtoValidator : AbstractValidator<MenuItemDto>
{
    public MenuItemDtoValidator()
    {
        RuleFor(x => x.RecipeId).NotEmpty();
        RuleFor(x => x.PortionSize).GreaterThan(0); // Portion size must be positive
    }
}