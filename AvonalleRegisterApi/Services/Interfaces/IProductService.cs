using AvonalleRegisterApi.DTOs;

namespace AvonalleRegisterApi.Services.Interfaces;

public interface IProductService
{
    Task<ProductDto> PostAsync(ProductDto model);
    Task<ProductDto> GetByIdAsync(int productId);
    Task<List<ProductDto>> GetAlllProductsAsync();
    Task<ProductDto> UpdateAsync(ProductDto model, int productId);
    Task<ProductDto> DeleteAsync(int productId);

}

