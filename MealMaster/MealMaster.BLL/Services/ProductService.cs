using AutoMapper;
using MealMaster.BLL.DTOs.Response.Product;
using MealMaster.BLL.Exceptions;
using MealMaster.BLL.Interfaces.Services;
using MealMaster.DAL.Interfaces;

namespace MealMaster.BLL.Services;

public class ProductService:IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var products = await _unitOfWork.Products.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
    }

    public async Task<ProductResponseDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id, cancellationToken);

        if (product is null)
        {
            throw new EntityNotFoundException("Product", id);
        }

        return _mapper.Map<ProductResponseDto>(product);
    }

    public async Task<ProductResponseDto> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var product = await _unitOfWork.Products.GetByNameAsync(name, cancellationToken);

        if (product is null)
        {
            throw new EntityNotFoundException("Product not found");
        }

        return _mapper.Map<ProductResponseDto>(product);
    }
}