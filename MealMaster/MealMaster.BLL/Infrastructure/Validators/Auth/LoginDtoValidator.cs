using FluentValidation;
using MealMaster.BLL.DTOs.Request.User;

namespace MealMaster.BLL.Infrastructure.Validators.Auth;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(100); // Adjust length requirements
    }
}