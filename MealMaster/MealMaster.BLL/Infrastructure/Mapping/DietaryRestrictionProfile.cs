using AutoMapper;
using MealMaster.BLL.DTOs.Response.DietaryRestriction;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class DietaryRestrictionProfile : Profile
    {
        public DietaryRestrictionProfile()
        {
            // Маппинг DietaryRestriction -> DietaryRestrictionResponseDto
            CreateMap<DietaryRestriction, DietaryRestrictionResponseDto>();
        }
    }
}