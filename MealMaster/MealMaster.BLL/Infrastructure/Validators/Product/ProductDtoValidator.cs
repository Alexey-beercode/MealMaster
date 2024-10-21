using FluentValidation;
using MealMaster.BLL.DTOs.Request.Product;

namespace MealMaster.BLL.Infrastructure.Validators.Product;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
    }
}