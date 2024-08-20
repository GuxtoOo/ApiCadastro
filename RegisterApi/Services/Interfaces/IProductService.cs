using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.ViewModel;

namespace AvonalleRegisterApi.Services.Interfaces;

public interface IProductService
{
    Task<CreateProductViewModel> PostAsync(CreateProductViewModel model);
    Task<ProductDto> GetByIdAsync(int productId);
    Task<List<ProductDto>> GetAlllProductsAsync();
    Task<CreateProductViewModel> UpdateAsync(CreateProductViewModel model, int productId);
    Task<ProductDto> DeleteAsync(int productId);

}

