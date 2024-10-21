using AutoMapper;
using MealMaster.BLL.DTOs.Response.Product;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Infrastructure.Mapping;

public class ProductProfile:Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponseDto>();
    }
}