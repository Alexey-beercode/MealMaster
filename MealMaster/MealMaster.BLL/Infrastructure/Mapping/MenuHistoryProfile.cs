using AutoMapper;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class MenuHistoryProfile : Profile
    {
        public MenuHistoryProfile()
        {
            // Маппинг MenuHistory -> MenuHistoryResponseDto
            CreateMap<MenuHistory, MenuHistoryResponseDto>();
        }
    }
}