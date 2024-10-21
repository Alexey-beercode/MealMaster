using MealMaster.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealMaster.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var prdocuts = await _productService.GetAllAsync(cancellationToken);
        return Ok(prdocuts);
    }

    [HttpGet("name/{name}")]
    public async Task<IActionResult> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetByNameAsync(name, cancellationToken);
        return Ok(product);
    }
    
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetByIdAsync(id, cancellationToken);
        return Ok(product);
    }
}