using AutoMapper;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.DTOs.Response.MenuItem;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.BLL.Interfaces.Facades;
using MealMaster.DAL.Interfaces;
using MealMaster.Domain.Entities;

namespace MealMaster.BLL.Facades;

public class MenuFacade : IMenuFacade
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

    private Dictionary<Guid, int> CalculatePortionSizes(List<RecipeResponseDto> recipes, int totalCalories)
    {
        // Словарь для хранения ID рецепта и соответствующего размера порции (в граммах)
        var portionSizes = new Dictionary<Guid, int>();

        // Количество рецептов
        int recipeCount = recipes.Count;

        // Калории, которые приходятся на каждый рецепт (равномерное распределение)
        int caloriesPerRecipe = totalCalories / recipeCount;

        // Для каждого рецепта вычисляем порцию в граммах
        foreach (var recipe in recipes)
        {
            // Калории на 1 грамм рецепта
            double caloriesPerGram = recipe.Calories / 100.0;

            // Сколько граммов нужно, чтобы получить caloriesPerRecipe калорий для данного рецепта
            double portionSizeInGrams = caloriesPerRecipe / caloriesPerGram;

            // Округляем до целого числа и добавляем в словарь
            portionSizes[recipe.Id] = (int)Math.Round(portionSizeInGrams);
        }

        return portionSizes;
    }

    // Создаем меню на основе данных из рецептов
    public async Task<MenuResponseDto> CreateFullMenyDtoFromRecipesAsync(List<RecipeResponseDto> recipeResponseDtos, Guid userId, int recipeCount, int totalCalories, CancellationToken cancellationToken = default)
    {
        // Получаем информацию о рецептах из базы данных с использованием UnitOfWork и RecipeFacade
        var menuItemsDtos = new List<MenuItemResponseDto>();

        foreach (var recipeDto in recipeResponseDtos)
        {
            // Получаем информацию о рецепте из базы данных через UnitOfWork
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(recipeDto.Id, cancellationToken);
        
            // Используем RecipeFacade для создания полного DTO рецепта
            var fullRecipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);

            // Создаем MenuItemResponseDto для этого рецепта
            var menuItemDto = new MenuItemResponseDto
            {
                RecipeResponseDto = fullRecipeDto,
                PortionSize = 0 // Порции будут рассчитаны позже
            };

            menuItemsDtos.Add(menuItemDto);
        }

        // Используем метод для расчета порций на основе общего количества калорий (например, 1500 ккал)
        var portionSizes = CalculatePortionSizes(recipeResponseDtos, totalCalories);

        // Применяем рассчитанные порции к элементам меню
        foreach (var menuItem in menuItemsDtos)
        {
            menuItem.PortionSize = portionSizes[menuItem.RecipeResponseDto.Id];
        }

        // Собираем MenuResponseDto
        var menuDto = new MenuResponseDto
        {
            Date = DateTime.UtcNow,
            MealCount = recipeCount,
            MenuItems = menuItemsDtos,
            UserId = userId,
            TotalCalories = totalCalories
        };

        return menuDto;
    }

    // Метод для создания полного меню DTO из сущности Menu
    public async Task<MenuResponseDto> CreateFullMenuDtoAsync(Menu menu, CancellationToken cancellationToken = default)
    {
        // Маппим сущность Menu на DTO
        var menuDto = _mapper.Map<MenuResponseDto>(menu);
        
        // Получаем список элементов меню из базы данных
        var menuItems = await _unitOfWork.Menus.GetMenuItemsByMenuId(menu.Id, cancellationToken);
        var menuItemsDtos = new List<MenuItemResponseDto>();

        // Для каждого элемента меню получаем рецепт и создаем DTO
        foreach (var menuItem in menuItems)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(menuItem.RecipeId, cancellationToken);
            var recipeDto = await _recipeFacade.CreateFullRecipeDtoAsync(recipe, cancellationToken);
            
            menuItemsDtos.Add(new MenuItemResponseDto
            {
                RecipeResponseDto = recipeDto,
                PortionSize = menuItem.PortionSize
            });
        }

        // Устанавливаем элементы меню в DTO
        menuDto.MenuItems = menuItemsDtos;

        return menuDto;
    }
}