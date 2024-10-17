using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.DTOs.Response.Recipe;

namespace MealMaster.BLL.Interfaces.Services;

public interface IMenuService
{
    Task<MenuResponseDto> GenerateMenuAsync(GenerateMenuDto generateMenuDto, CancellationToken cancellationToken = default);
    Task AddMenuToUserAsync(SetMenuToUserDto menuToUserDto, CancellationToken cancellationToken = default);
    Task DeleteAsync(DeleteMenuDto deleteMenuDto, CancellationToken cancellationToken = default);
    Task CreateAsync(CreateMenuDto createMenuDto, CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<MenuResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
}