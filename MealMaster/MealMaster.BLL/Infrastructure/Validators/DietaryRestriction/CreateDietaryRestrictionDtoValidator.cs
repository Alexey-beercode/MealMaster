using FluentValidation;
using MealMaster.BLL.DTOs.Request.DietaryRestriction;

namespace MealMaster.BLL.Infrastructure.Validators.DietaryRestriction;

public class CreateDietaryRestrictionDtoValidator : AbstractValidator<CreateDietaryRestrictionDto>
{
    public CreateDietaryRestrictionDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
    }
}