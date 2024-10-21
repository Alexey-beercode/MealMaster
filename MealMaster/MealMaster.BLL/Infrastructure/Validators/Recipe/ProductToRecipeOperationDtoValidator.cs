using FluentValidation;
using MealMaster.BLL.DTOs.Request.Recipe;

namespace MealMaster.BLL.Infrastructure.Validators.Recipe;

public class ProductToRecipeOperationDtoValidator : AbstractValidator<ProductToRecipeOperationDto>
{
    public ProductToRecipeOperationDtoValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.RecipeId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        // IsAdding doesn't require specific validation, as it's a boolean
    }
}