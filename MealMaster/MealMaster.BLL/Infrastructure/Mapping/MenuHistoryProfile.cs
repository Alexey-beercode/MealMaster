using AutoMapper;
using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class MenuHistoryProfile : Profile
    {
        public MenuHistoryProfile()
        {
            CreateMap<MenuHistory, MenuHistoryResponseDto>();
            CreateMap<SetMenuToUserDto, MenuHistory>();
        }
    }
}