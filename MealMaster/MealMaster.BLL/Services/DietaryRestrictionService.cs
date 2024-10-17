using AutoMapper;
using MealMaster.BLL.DTOs.Response.DietaryRestriction;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;

namespace MealMaster.BLL.Services;

public class DietaryRestrictionService:IDietaryRestrictionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DietaryRestrictionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DietaryRestrictionResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var restrictions = await _unitOfWork.DietaryRestrictions.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<DietaryRestrictionResponseDto>>(restrictions);
    }

    public async Task<DietaryRestrictionResponseDto> GetByIdAsync(Guid restrictionId, CancellationToken cancellationToken = default)
    {
        var resriction = await _unitOfWork.DietaryRestrictions.GetByIdAsync(restrictionId, cancellationToken);

        if (resriction is null)
        {
            throw new EntityNotFoundException("Restriction", restrictionId);
        }

        return _mapper.Map<DietaryRestrictionResponseDto>(resriction);
    }

    public async Task<IEnumerable<DietaryRestrictionResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var resrictionsByUser =
            await _unitOfWork.DietaryRestrictions.GetUserRestrictionsAsync(userId, cancellationToken);
        return _mapper.Map<IEnumerable<DietaryRestrictionResponseDto>>(resrictionsByUser);
    }
}