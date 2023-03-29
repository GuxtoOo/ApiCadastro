using AvonalleRegisterApi.DTOs;

namespace AvonalleRegisterApi.Services.Interfaces;

public interface IProductService
{
    Task<ProductDto> PostAsync(ProductDto model);
    Task<ProductDto> GetByIdAsync(int productId);
}

