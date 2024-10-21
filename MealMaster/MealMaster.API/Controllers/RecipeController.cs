using MealMaster.BLL.DTOs.Request.Recipe;
using MealMaster.BLL.DTOs.Response.Recipe;
using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeResponseDto>>> GetAll(CancellationToken cancellationToken)
        {
            var recipes = await _recipeService.GetAllAsync(cancellationToken);
            return Ok(recipes);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RecipeResponseDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var recipe = await _recipeService.GetByIdAsync(id, cancellationToken);
            return Ok(recipe);
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<RecipeResponseDto>>> GetByFilter([FromBody] RecipeFilterDto recipeFilterDto, CancellationToken cancellationToken)
        {
            var recipes = await _recipeService.GetByFilterAsync(recipeFilterDto, cancellationToken);
            return Ok(recipes);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDto createRecipeDto, CancellationToken cancellationToken)
        {
            await _recipeService.CreateAsync(createRecipeDto, cancellationToken);
            return NoContent();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateRecipe([FromBody] UpdateRecipeDto updateRecipeDto, CancellationToken cancellationToken)
        {
            await _recipeService.UpdateAsync(updateRecipeDto, cancellationToken);
            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteRecipe([FromBody] DeleteRecipeDto deleteRecipeDto, CancellationToken cancellationToken)
        {
            await _recipeService.DeleteAsync(deleteRecipeDto, cancellationToken);
            return NoContent();
        }

        [Authorize]
        [HttpPost("product-operation")]
        public async Task<IActionResult> ProductToRecipeOperation([FromBody] ProductToRecipeOperationDto productToRecipeOperationDto, CancellationToken cancellationToken)
        {
            await _recipeService.ProductToRecipeOperationAsync(productToRecipeOperationDto, cancellationToken);
            return NoContent();
        }
    }
}