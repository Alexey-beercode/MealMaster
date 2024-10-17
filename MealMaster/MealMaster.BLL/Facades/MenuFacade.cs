using AutoMapper;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.DTOs.Response.MenuItem;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.BLL.Interfaces.Facades;
using MealMaster.DAL.Interfaces;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Facades;

public class MenuFacade:IMenuFacade
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRecipeFacade _recipeFacade;

    public MenuFacade(IMapper mapper, IUnitOfWork unitOfWork, IRecipeFacade recipeFacade)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _recipeFacade = recipeFacade;
    }

    public async Task<MenuResponseDto> CreateFullMenuDtoAsync(Menu menu, CancellationToken cancellationToken = default)
    {
        var menuDto = _mapper.Map<MenuResponseDto>(menu);
        var menuItems = await _unitOfWork.Menus.GetMenuItemsByMenuId(menu.Id, cancellationToken);
        var menuItemsDtos = new List<MenuItemResponseDto>();
        
        foreach (var menuItem in menuItems)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(menuItem.RecipeId, cancellationToken);
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            
            menuItemsDtos.Add(new MenuItemResponseDto(){RecipeResponseDto = recipeDto,PortionSize = menuItem.PortionSize});
        }

        menuDto.MenuItems = menuItemsDtos;
        return menuDto;
    }

    public async Task<MenuResponseDto> CreateFullMenyDtoFromRecipesAsync(List<RecipeResponseDto> recipeResponseDtos,Guid userId,int recipeCount,
        CancellationToken cancellationToken = default)
    {
        var menuItemsDtos = new List<MenuItemResponseDto>();
        foreach (var recipe in recipeResponseDtos)
        {
            var menuItems = await _unitOfWork.Menus.GetMenuItemsByRecipeIdAsync(recipe.Id, cancellationToken);
            var averagePortionSize = (int)menuItems.Select(item => item.PortionSize).Average();
            
            var menuItemDto = new MenuItemResponseDto()
                { PortionSize = averagePortionSize, RecipeResponseDto = recipe };
            
            menuItemsDtos.Add(menuItemDto);
        }

        var menuDto = new MenuResponseDto()
        {
            Date = DateTime.UtcNow,
            MealCount = recipeCount,
            MenuItems = menuItemsDtos,
            UserId = userId,
            TotalCalories = recipeResponseDtos.Select(dto => dto.Calories).Sum()
        };

        return menuDto;
    }
}