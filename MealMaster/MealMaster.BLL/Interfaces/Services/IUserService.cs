using MealMaster.BLL.DTOs.Request.User;
using MealMaster.BLL.DTOs.Response.User;

namespace MealMaster.BLL.Interfaces.Services;

public interface IUserService
{
   Task<IEnumerable<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
   Task<UserResponseDto> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default);
   Task<UserResponseDto> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
   Task DeleteAsync(Guid userId, CancellationToken cancellationToken = default);
   Task UpdateAsync(Guid userId, UpdateUserDto updateUserDto, CancellationToken cancellationToken = default);
}