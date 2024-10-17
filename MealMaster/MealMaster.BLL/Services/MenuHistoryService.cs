using AutoMapper;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;

namespace MealMaster.BLL.Services;

public class MenuHistoryService:IMenuHistoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MenuHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MenuHistoryResponseDto> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var histories = await _unitOfWork.MenuHistories.GetMenuHistoryByUserIdAsync(userId, cancellationToken);
        return _mapper.Map<MenuHistoryResponseDto>(histories);
    }
}