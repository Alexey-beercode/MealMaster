using MealMaster.BLL.DTOs.Request.Menu;
using MealMaster.BLL.DTOs.Response.Menu;
using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuResponseDto>>> GetAll(CancellationToken cancellationToken)
        {
            var menus = await _menuService.GetAllAsync(cancellationToken);
            return Ok(menus);
        }

        [Authorize]
        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<IEnumerable<MenuResponseDto>>> GetByUserId(Guid userId, CancellationToken cancellationToken)
        {
            var menus = await _menuService.GetByUserIdAsync(userId, cancellationToken);
            return Ok(menus);
        }

        [Authorize]
        [HttpPost("generate")]
        public async Task<ActionResult<MenuResponseDto>> GenerateMenu([FromBody] GenerateMenuDto generateMenuDto, CancellationToken cancellationToken)
        {
            var menu = await _menuService.GenerateMenuAsync(generateMenuDto, cancellationToken);
            return Ok(menu);
        }

        [Authorize]
        [HttpPost("addtouser")]
        public async Task<IActionResult> AddMenuToUser([FromBody] SetMenuToUserDto menuToUserDto, CancellationToken cancellationToken)
        {
            await _menuService.AddMenuToUserAsync(menuToUserDto, cancellationToken);
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMenu([FromBody] CreateMenuDto createMenuDto, CancellationToken cancellationToken)
        {
            await _menuService.CreateAsync(createMenuDto, cancellationToken);
            return Created();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteMenu([FromBody] DeleteMenuDto deleteMenuDto, CancellationToken cancellationToken)
        {
            await _menuService.DeleteAsync(deleteMenuDto, cancellationToken);
            return NoContent();
        }
    }
}