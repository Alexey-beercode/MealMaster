using MealMaster.BLL.DTOs.Response.DietaryRestriction;

namespace MealMaster.BLL.Interfaces.Services;

public interface IDietaryRestrictionService
{
    Task<IEnumerable<DietaryRestrictionResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<DietaryRestrictionResponseDto> GetByIdAsync(Guid restrictionId, CancellationToken cancellationToken = default);
    Task<IEnumerable<DietaryRestrictionResponseDto>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken = default);
}