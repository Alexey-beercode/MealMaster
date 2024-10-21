using FluentValidation;
using MealMaster.BLL.DTOs.Request.User;

namespace MealMaster.BLL.Infrastructure.Validators.Auth;

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Age).GreaterThanOrEqualTo(0);
    }
}