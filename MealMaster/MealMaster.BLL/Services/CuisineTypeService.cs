using AutoMapper;
using MealMaster.BLL.DTOs.Response.CuisineType;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;

namespace MealMaster.BLL.Services;

public class CuisineTypeService:ICuisineTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CuisineTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CuisineTypeResponseDto> GetByIdAsync(Guid cuisineTypeId, CancellationToken cancellationToken = default)
    {
        var cuisineType = await _unitOfWork.CuisineTypes.GetByIdAsync(cuisineTypeId, cancellationToken);

        if (cuisineType is null)
        {
            throw new EntityNotFoundException("CuisineType", cuisineTypeId);
        }

        return _mapper.Map<CuisineTypeResponseDto>(cuisineType);
    }

    public async Task<IEnumerable<CuisineTypeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cuisineTypes = await _unitOfWork.CuisineTypes.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CuisineTypeResponseDto>>(cuisineTypes);
    }

    public async Task<CuisineTypeResponseDto> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var cuisineType = await _unitOfWork.CuisineTypes.GetByNameAsync(name, cancellationToken);

        if (cuisineType is null)
        {
            throw new EntityNotFoundException($"CuisineType with name : {name}");
        }

        return _mapper.Map<CuisineTypeResponseDto>(cuisineType);
    }
}