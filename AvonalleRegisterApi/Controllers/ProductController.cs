using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvonalleRegisterApi.Controllers;

public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [Authorize]
    [HttpPost("v1/products")]
    public async Task<IActionResult> PostAsync([FromBody] ProductDto model)
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

    [Authorize]
    [HttpGet("v1/products/{productId:int}")]
    public async Task<IActionResult> GetByIdtAsync(int productId)
    {
        try
        {
            var response = await _productService.GetByIdAsync(productId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao tentar retornar um produto: {ex.Message}");
        };
    }

    [Authorize]
    [HttpGet("v1/products")]
    public async Task<IActionResult> GetAlllProductsAsync()
    {
        try
        {
            var response = await _productService.GetAlllProductsAsync();
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao tentar retornar os produtos: {ex.Message}");
        };
    }

    [Authorize]
    [HttpPut("v1/products/{productId:int}")]
    public async Task<IActionResult> UpdateAsync([FromBody]ProductDto model,int productId)
    {
        try
        {
            var response = await _productService.UpdateAsync(model, productId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao tentar retornar os produtos: {ex.Message}");
        };
    }

    [Authorize]
    [HttpDelete("v1/products/{productId:int}")]
    public async Task<IActionResult> DeleteAsync( int productId)
    {
        try
        {
            var response = await _productService.DeleteAsync( productId);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao tentar excluir o produto: {ex.Message}");
        };
    }
}
