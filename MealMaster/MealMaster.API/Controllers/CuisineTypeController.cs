using MealMaster.BLL.DTOs.Response.CuisineType;
using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuisineTypeController : ControllerBase
    {
        private readonly ICuisineTypeService _cuisineTypeService;

        public CuisineTypeController(ICuisineTypeService cuisineTypeService)
        {
            _cuisineTypeService = cuisineTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuisineTypeResponseDto>>> GetAll(CancellationToken cancellationToken)
        {
            var cuisineTypes = await _cuisineTypeService.GetAllAsync(cancellationToken);
            return Ok(cuisineTypes);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CuisineTypeResponseDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var cuisineType = await _cuisineTypeService.GetByIdAsync(id, cancellationToken);
            return Ok(cuisineType);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<CuisineTypeResponseDto>> GetByName(string name, CancellationToken cancellationToken)
        {
            var cuisineType = await _cuisineTypeService.GetByNameAsync(name, cancellationToken);
            return Ok(cuisineType);
        }
    }
}