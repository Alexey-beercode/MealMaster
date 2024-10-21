using AutoMapper;
using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.User;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Маппинг User -> UserResponseDto
            CreateMap<User, UserResponseDto>();

            // Маппинг RegisterUserDto -> User
            CreateMap<RegisterDto, User>();

            // Маппинг LoginDto -> User
            CreateMap<LoginDto, User>();

            // Маппинг RegisterUserDto -> LoginDto
            CreateMap<RegisterDto, LoginDto>();
        }
    }
}