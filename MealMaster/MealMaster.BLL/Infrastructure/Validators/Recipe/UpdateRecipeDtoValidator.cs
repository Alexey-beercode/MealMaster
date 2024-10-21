using FluentValidation;
using MealMaster.BLL.DTOs.Request.Recipe;

namespace MealMaster.BLL.Infrastructure.Validators.Recipe;

public class UpdateRecipeDtoValidator : AbstractValidator<UpdateRecipeDto>
{
    public UpdateRecipeDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Description).MaximumLength(1000);
        RuleFor(x => x.Calories).GreaterThan(0);
        RuleFor(x => x.PreparationTime).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CuisineTypeId).NotEmpty();
        RuleFor(x => x.RestrictionId).NotEmpty();
    }
}