using MealMaster.BLL.DTOs.Request.Product;
using MealMaster.BLL.DTOs.Response.Product;

namespace MealMaster.BLL.Interfaces.Services;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ProductResponseDto> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}