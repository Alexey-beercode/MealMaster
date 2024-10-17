using MealMaster.BLL.DTOs.Response.Menu;

namespace MealMaster.BLL.Interfaces.Services;

public interface IMenuHistoryService
{
    Task<MenuHistoryResponseDto> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}