using FluentValidation;
using MealMaster.BLL.DTOs.Request.User;

namespace MealMaster.BLL.Infrastructure.Validators.Auth;


public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Age).GreaterThanOrEqualTo(0); // Or a more realistic minimum age
        RuleFor(x => x.DietaryRestrictionsIds).NotNull(); // Can be empty, but not null
    }
}