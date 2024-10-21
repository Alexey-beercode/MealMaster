using FluentValidation;
using MealMaster.BLL.DTOs.Request.Menu;

namespace MealMaster.BLL.Infrastructure.Validators.Menu;

public class CreateMenuDtoValidator : AbstractValidator<CreateMenuDto>
{
    public CreateMenuDtoValidator()
    {
        RuleFor(x => x.MenuItems).NotEmpty(); // At least one menu item
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.TotalCalories).GreaterThanOrEqualTo(0);
    }
}

