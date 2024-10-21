using FluentValidation;
using MealMaster.BLL.DTOs.Request.Recipe;

namespace MealMaster.BLL.Infrastructure.Validators.Recipe;

public class CreateRecipeDtoValidator : AbstractValidator<CreateRecipeDto>
{
    public CreateRecipeDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Description).MaximumLength(1000); // Or whatever your maximum description length is
        RuleFor(x => x.Calories).GreaterThan(0);
        RuleFor(x => x.PreparationTime).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CuisineTypeId).NotEmpty();
        RuleFor(x => x.RestrictionId).NotEmpty();
        RuleFor(x => x.ProductIds).NotNull(); // Shouldn't be null, can be empty
    }
}