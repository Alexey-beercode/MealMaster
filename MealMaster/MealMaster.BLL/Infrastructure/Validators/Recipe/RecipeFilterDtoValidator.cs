using FluentValidation;
using MealMaster.BLL.DTOs.Request.Recipe;

namespace MealMaster.BLL.Infrastructure.Validators.Recipe;

public class RecipeFilterDtoValidator : AbstractValidator<RecipeFilterDto>
{
    public RecipeFilterDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.SearchTerm).MaximumLength(255); // Optional, but limit length

        When(x => x.MinCalories.HasValue && x.MaxCalories.HasValue, () =>
        {
            RuleFor(x => x.MinCalories).LessThanOrEqualTo(x => x.MaxCalories);
        });

        When(x => x.MinPreparationTime.HasValue && x.MaxPreparationTime.HasValue, () =>
        {
            RuleFor(x => x.MinPreparationTime).LessThanOrEqualTo(x => x.MaxPreparationTime);
        });

        // CuisineTypeId and RestrictionId are optional Guids, no further validation needed here.

    }
}