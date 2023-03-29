using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AvonalleRegisterApi.Controllers;

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("v1/products")]
    public async Task<IActionResult> PostAsync([FromBody]ProductDto model)
    {
        try
        {
            var response = await _productService.PostAsync(model);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao tentar inserir um novo produto: {ex.Message}");
        };
    }

    [HttpGet("v1/products/{productId:int}")]
    public async Task<IActionResult> GetByIdtAsync(int productId)
    {
        try
        {
            var response = await _productService.GetByIdtAsync(productId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao tentar retornar um produto: {ex.Message}");
        };
    }
}
