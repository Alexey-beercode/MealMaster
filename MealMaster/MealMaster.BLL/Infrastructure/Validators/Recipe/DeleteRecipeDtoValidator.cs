using FluentValidation;
using MealMaster.BLL.DTOs.Request.Recipe;

namespace MealMaster.BLL.Infrastructure.Validators.Recipe;

public class DeleteRecipeDtoValidator : AbstractValidator<DeleteRecipeDto>
{
    public DeleteRecipeDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.RecipeId).NotEmpty();
    }
}