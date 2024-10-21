using FluentValidation;
using MealMaster.BLL.DTOs.Request.Menu;

namespace MealMaster.BLL.Infrastructure.Validators.Menu;

public class GenerateMenuDtoValidator : AbstractValidator<GenerateMenuDto>
{
    public GenerateMenuDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.RecipeCount).GreaterThan(0); // Must generate at least one recipe
        RuleFor(x => x.Calories).GreaterThan(0); // Calories must be positive
    }
}