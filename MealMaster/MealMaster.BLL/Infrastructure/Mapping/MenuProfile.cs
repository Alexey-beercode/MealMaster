using AutoMapper;
using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            // Маппинг Menu -> MenuResponseDto
            CreateMap<Menu, MenuResponseDto>();

            // Маппинг CreateMenuDto -> Menu
            CreateMap<CreateMenuDto, Menu>();

            // Маппинг DeleteMenuDto -> Menu
            CreateMap<DeleteMenuDto, Menu>();

            // Маппинг GenerateMenuDto -> Menu
            CreateMap<GenerateMenuDto, Menu>();
            
            CreateMap<SetMenuToUserDto, Menu>();
        }
    }
}