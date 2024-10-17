using MealMaster.BLL.DTOs.Response.CuisineType;

namespace MealMaster.BLL.Interfaces.Services;

public interface ICuisineTypeService
{
    Task<CuisineTypeResponseDto> GetByIdAsync(Guid cuisineTypeId, CancellationToken cancellationToken = default);
    Task<IEnumerable<CuisineTypeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CuisineTypeResponseDto> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}