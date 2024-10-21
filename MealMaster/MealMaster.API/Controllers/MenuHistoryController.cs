using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MenuHistoryController : ControllerBase
    {
        private readonly IMenuHistoryService _menuHistoryService;

        public MenuHistoryController(IMenuHistoryService menuHistoryService)
        {
            _menuHistoryService = menuHistoryService;
        }
        
        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<MenuHistoryResponseDto>> GetByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var menuHistory = await _menuHistoryService.GetByUserIdAsync(userId, cancellationToken);
            return Ok(menuHistory);
        }
    }
}