using FluentValidation;
using MealMaster.BLL.DTOs.Request.CuisineType;

namespace MealMaster.BLL.Infrastructure.Validators.CuisineType;


public class CreateCuisineTypeDtoValidator : AbstractValidator<CreateCuisineTypeDto>
{
    public CreateCuisineTypeDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
    }
}