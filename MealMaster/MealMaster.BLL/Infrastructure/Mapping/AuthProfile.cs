using AutoMapper;
using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.Auth;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // Маппинг User -> AuthResponseDto
            CreateMap<User, AuthResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

            // Маппинг RegisterDto -> User
            CreateMap<RegisterDto, User>();

            // Маппинг LoginDto -> User
            CreateMap<LoginDto, User>();

            // Маппинг RegisterDto -> LoginDto
            CreateMap<RegisterDto, LoginDto>();
        }
    }
}