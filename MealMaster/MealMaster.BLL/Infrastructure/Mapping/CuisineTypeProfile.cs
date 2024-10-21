using AutoMapper;
using MealMaster.BLL.DTOs.Response.CuisineType;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class CuisineTypeProfile : Profile
    {
        public CuisineTypeProfile()
        {
            // Маппинг CuisineType -> CuisineTypeResponseDto
            CreateMap<CuisineType, CuisineTypeResponseDto>();
        }
    }
}