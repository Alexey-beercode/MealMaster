using AutoMapper;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.Interfaces.Facades;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;

namespace MealMaster.BLL.Services;

public class MenuHistoryService:IMenuHistoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMenuFacade _menuFacade;

    public MenuHistoryService(IUnitOfWork unitOfWork, IMapper mapper, IMenuFacade menuFacade)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _menuFacade = menuFacade;
    }

    public async Task<IEnumerable<MenuHistoryResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var histories = await _unitOfWork.MenuHistories.GetMenuHistoryByUserIdAsync(userId, cancellationToken);
        var historyDtos= new List<MenuHistoryResponseDto>();

        foreach (var menuHistory in histories)
        {
            var menu = await _unitOfWork.Menus.GetByIdAsync(menuHistory.MenuId);
            var menuHistoryDto = _mapper.Map<MenuHistoryResponseDto>(menuHistory);
            menuHistoryDto.Menu =await _menuFacade.CreateFullMenuDtoAsync(menu, cancellationToken);
            historyDtos.Add(menuHistoryDto);
        }

        return historyDtos;
    }
}