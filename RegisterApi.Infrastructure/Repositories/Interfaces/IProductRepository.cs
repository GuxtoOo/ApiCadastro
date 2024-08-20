using AvonalleRegisterApi.Domain.Models;

namespace AvonalleRegisterApi.Infrastructure.Repositories;

public interface IProductRepository
{
    Task<Product> PostAsync(Product model);
    Task<Product> GetByIdAsync(int productId);
    Task<List<Product>> GetAllProductsAsync();
    Task UpdateAsync(Product model);
    Task DeleteAsync(Product model);
}
