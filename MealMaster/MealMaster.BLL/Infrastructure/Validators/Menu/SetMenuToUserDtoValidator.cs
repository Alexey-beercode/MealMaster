using FluentValidation;
using MealMaster.BLL.DTOs.Request.Menu;

namespace MealMaster.BLL.Infrastructure.Validators.Menu;

public class SetMenuToUserDtoValidator : AbstractValidator<SetMenuToUserDto>
{
    public SetMenuToUserDtoValidator()
    {
        RuleFor(x => x.MenuId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}