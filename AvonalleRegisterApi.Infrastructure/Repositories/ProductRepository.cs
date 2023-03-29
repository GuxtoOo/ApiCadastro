using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AvonalleRegisterApi.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AvonalleContext _dataContext;

    public ProductRepository(AvonalleContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Product> PostAsync(Product model)
    {
        _dataContext.Produtos.Add(model);
        await _dataContext.SaveChangesAsync();
        return model;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var response = await _dataContext.Produtos
            .OrderBy(s => s.Nome)
            .ToListAsync();
        return response;
    }

    public async Task<Product?> GetByIdAsync(int productId)
    {
        var response = await _dataContext.Produtos
            .Where(s => s.Id == productId)
            .FirstOrDefaultAsync();
        return response;
    }

    public async Task UpdateAsync(Product model)
    {
        _dataContext.Produtos.Update(model);
        await _dataContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product model)
    {
        _dataContext.Produtos.Remove(model);
        await _dataContext.SaveChangesAsync();
    }

}

