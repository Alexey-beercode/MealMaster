﻿using AutoMapper;
using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Interfaces.Facades;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;
using MealMaster.Domain.Entities;
using MealMaster.Domain.Models;

namespace MealMaster.BLL.Services;

public class MenuService : IMenuService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRecipeFacade _recipeFacade;
    private readonly IMenuFacade _menuFacade;
    private readonly IRecipeService _recipeService;

    public MenuService(IUnitOfWork unitOfWork, IMapper mapper, IRecipeFacade recipeFacade, IMenuFacade menuFacade, IRecipeService recipeService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _recipeFacade = recipeFacade;
        _menuFacade = menuFacade;
        _recipeService = recipeService;
    }

    public async Task<MenuResponseDto> GenerateMenuAsync(GenerateMenuDto generateMenuDto, CancellationToken cancellationToken = default)
    {
        var allUserRecipes = await _unitOfWork.Menus.GetMenuGenerationDataAsync(generateMenuDto.UserId, generateMenuDto.RecipeCount, generateMenuDto.Calories, cancellationToken);
        var userPreferences = await _recipeService.GetUserPreferencesAsync(generateMenuDto.UserId, cancellationToken);

        int averageCaloriesPerMeal = generateMenuDto.Calories / generateMenuDto.RecipeCount;

        var suitableRecipes = _recipeService.FilterRecipesByPreferences(allUserRecipes, userPreferences)
            .Where(r => IsRecipeSuitable(r, averageCaloriesPerMeal))
            .ToList();

        suitableRecipes = AdjustRecipeCount(suitableRecipes, allUserRecipes, generateMenuDto.RecipeCount, averageCaloriesPerMeal);

        var recipeResponseDtos = new List<RecipeResponseDto>();
        foreach (var recipe in suitableRecipes)
        {
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            recipeResponseDtos.Add(recipeDto);
        }

        // Передаем totalCalories как generateMenuDto.Calories
        return await _menuFacade.CreateFullMenyDtoFromRecipesAsync(
            recipeResponseDtos, 
            generateMenuDto.UserId, 
            recipeResponseDtos.Count, 
            generateMenuDto.Calories, 
            cancellationToken
        );
    }

    public async Task AddMenuToUserAsync(SetMenuToUserDto menuToUserDto, CancellationToken cancellationToken = default)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(menuToUserDto.MenuId, cancellationToken);

        if (menu is null)
        {
            throw new EntityNotFoundException("Menu", menuToUserDto.MenuId);
        }

        var menuHistoryResord = _mapper.Map<MenuHistory>(menuToUserDto);
        menuHistoryResord.CreatedDate=DateTime.UtcNow;
        await _unitOfWork.Menus.AddMenuToUserAsync(menuHistoryResord);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteMenuDto deleteMenuDto, CancellationToken cancellationToken = default)
    {
        var menu = await _unitOfWork.Menus.GetByIdAsync(deleteMenuDto.MenuId, cancellationToken);

        if (menu is null)
        {
            throw new EntityNotFoundException("Menu", deleteMenuDto.MenuId);
        }

        if (deleteMenuDto.UserId!=menu.UserId)
        {
            throw new InvalidOperationException("This user cant delete menu");
        }
        
        _unitOfWork.Menus.Delete(menu);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateAsync(CreateMenuDto createMenuDto, CancellationToken cancellationToken = default)
    {
        var menu = _mapper.Map<Menu>(createMenuDto);
        var dateNow = DateTime.UtcNow;
        menu.Date=dateNow;
        menu.MealCount = createMenuDto.MenuItems.Count;
        
        await _unitOfWork.Menus.CreateAsync(menu, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        var newMenu = await _unitOfWork.Menus.GetByDateAsync(dateNow, cancellationToken);
        
        var menuHistory = new MenuHistory()
            { CreatedDate = DateTime.UtcNow, MenuId = newMenu.Id, UserId = createMenuDto.UserId };
        await _unitOfWork.MenuHistories.CreateAsync(menuHistory, cancellationToken);
        
        foreach (var menuItemDto in createMenuDto.MenuItems)
        {
            var recipeId = menuItemDto.RecipeId;
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(recipeId, cancellationToken);

            if (recipe is null)
            {
                throw new EntityNotFoundException("Recipe", recipeId);
            }

            await _unitOfWork.Menus.CreateMenuItemAsync(new MenuItem()
                { MenuId = newMenu.Id, PortionSize = menuItemDto.PortionSize, RecipeId = recipeId });
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<MenuResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var menus = await _unitOfWork.Menus.GetAllAsync(cancellationToken);
        var menusDtos = new List<MenuResponseDto>();
        foreach (var menu in menus)
        {
            var menuDto = await _menuFacade.CreateFullMenuDtoAsync(menu, cancellationToken);
            menusDtos.Add(menuDto);
        }

        return menusDtos;
    }

    public async Task<IEnumerable<MenuResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var menusByUser = await _unitOfWork.Menus.GetMenusByUserIdAsync(userId, cancellationToken);
        var menusDtos = new List<MenuResponseDto>();
        
        foreach (var menu in menusByUser)
        {
            menusDtos.Add(await _menuFacade.CreateFullMenuDtoAsync(menu,cancellationToken));
        }

        return menusDtos;
    }



    private bool IsRecipeSuitable(Recipe recipe, int averageCaloriesPerMeal)
    {
        return recipe.Calories >= averageCaloriesPerMeal * 0.8 && recipe.Calories <= averageCaloriesPerMeal * 1.2;
    }

    private List<Recipe> AdjustRecipeCount(List<Recipe> suitableRecipes, IEnumerable<Recipe> allRecipes, int mealsPerDay, int averageCaloriesPerMeal)
    {
        if (suitableRecipes.Count < mealsPerDay)
        {
            var additionalRecipes = allRecipes
                .Except(suitableRecipes)
                .OrderBy(r => Math.Abs(r.Calories - averageCaloriesPerMeal))
                .Take(mealsPerDay - suitableRecipes.Count);

            suitableRecipes.AddRange(additionalRecipes);
        }

        if (suitableRecipes.Count > mealsPerDay)
        {
            suitableRecipes = suitableRecipes
                .OrderBy(x => Guid.NewGuid())
                .Take(mealsPerDay)
                .ToList();
        }

        return suitableRecipes;
    }
}