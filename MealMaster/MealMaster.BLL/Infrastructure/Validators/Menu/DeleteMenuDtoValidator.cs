using FluentValidation;
using MealMaster.BLL.DTOs.Request.Menu;

namespace MealMaster.BLL.Infrastructure.Validators.Menu;

public class DeleteMenuDtoValidator : AbstractValidator<DeleteMenuDto>
{
    public DeleteMenuDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.MenuId).NotEmpty();
    }
}