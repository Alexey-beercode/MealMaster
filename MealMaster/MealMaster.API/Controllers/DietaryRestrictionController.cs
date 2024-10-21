using MealMaster.BLL.DTOs.Response.DietaryRestriction;
using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietaryRestrictionController : ControllerBase
    {
        private readonly IDietaryRestrictionService _dietaryRestrictionService;

        public DietaryRestrictionController(IDietaryRestrictionService dietaryRestrictionService)
        {
            _dietaryRestrictionService = dietaryRestrictionService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietaryRestrictionResponseDto>>> GetAll(CancellationToken cancellationToken)
        {
                var restrictions = await _dietaryRestrictionService.GetAllAsync(cancellationToken);
                return Ok(restrictions);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DietaryRestrictionResponseDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
                var restriction = await _dietaryRestrictionService.GetByIdAsync(id, cancellationToken);
                return Ok(restriction);
        }
        
        [HttpGet("user/{userId:guid}")]
        public async Task<ActionResult<IEnumerable<DietaryRestrictionResponseDto>>> GetByUserId(Guid userId, CancellationToken cancellationToken)
        {
                var restrictions = await _dietaryRestrictionService.GetByUserIdAsync(userId, cancellationToken);
                return Ok(restrictions);
        }
    }
}