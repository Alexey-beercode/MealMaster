using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.DAL.Specifications;

public class RecipeFilterSpecification : BaseSpecification<Recipe>
{
    public RecipeFilterSpecification(RecipeFilterModel filterModel) 
        : base(r => true)
    {
        if (!string.IsNullOrEmpty(filterModel.SearchTerm))
        {
            AndAlso(r => r.Name.Contains(filterModel.SearchTerm) || r.Description.Contains(filterModel.SearchTerm));
        }

        if (filterModel.MinCalories.HasValue)
        {
            AndAlso(r => r.Calories >= filterModel.MinCalories.Value);
        }

        if (filterModel.MaxCalories.HasValue)
        {
            AndAlso(r => r.Calories <= filterModel.MaxCalories.Value);
        }

        if (filterModel.MinPreparationTime.HasValue)
        {
            AndAlso(r => r.PreparationTime >= filterModel.MinPreparationTime.Value);
        }

        if (filterModel.MaxPreparationTime.HasValue)
        {
            AndAlso(r => r.PreparationTime <= filterModel.MaxPreparationTime.Value);
        }

        if (filterModel.CuisineTypeId.HasValue)
        {
            AndAlso(r => r.CuisineTypeId == filterModel.CuisineTypeId.Value);
        }

        if (filterModel.RestrictionId.HasValue)
        {
            AndAlso(r => r.RestrictionId == filterModel.RestrictionId.Value);
        }
    }

    protected void AndAlso(Expression<Func<Recipe, bool>> criteria)
    {
        var parameter = Expression.Parameter(typeof(Recipe));
        var body = Expression.AndAlso(
            Expression.Invoke(Criteria, parameter),
            Expression.Invoke(criteria, parameter)
        );
        Criteria = Expression.Lambda<Func<Recipe, bool>>(body, parameter);
    }
}