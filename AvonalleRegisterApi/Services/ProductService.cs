using AutoMapper;
using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Infrastructure.Repositories;
using AvonalleRegisterApi.Services.Interfaces;
using AvonalleRegisterApi.ViewModel;

namespace AvonalleRegisterApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CreateProductViewModel> PostAsync(CreateProductViewModel model)
        {
            if (model == null)
                throw new Exception("É preciso conter um produto.");

            var mappingModel = _mapper.Map<Product>(model);
            var response = await _productRepository.PostAsync(mappingModel);
            return _mapper.Map<CreateProductViewModel>(response);
        }
        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            if (productId.Equals(0) || productId == null)
                throw new Exception("Informe um id.");

            var response = await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductDto>(response);
        }
        public async Task<List<ProductDto>> GetAlllProductsAsync()
        {
            var response = await _productRepository.GetAllProductsAsync();
            if (response.Count == 0)
                throw new Exception("Nenhum produto foi encontrado.");
            return _mapper.Map<List<ProductDto>>(response);
        }
        public async Task<CreateProductViewModel> UpdateAsync(CreateProductViewModel model, int productId)
        {
            if (productId.Equals(0) || productId == null)
                throw new Exception("Informe um id.");
            if (model == null)
                throw new Exception("Informe uma model.");

            var produto = await GetByIdAsync(productId);

            produto.Nome = model.Nome;
            produto.Descricao = model.Descricao;
            produto.Preco = model.Preco;

            var mappingProduct = _mapper.Map<Product>(produto);
            await _productRepository.UpdateAsync(mappingProduct);
            return _mapper.Map<CreateProductViewModel>(mappingProduct);
        }
        public async Task<ProductDto> DeleteAsync(int productId)
        {
            if (productId.Equals(0) || productId == null)
                throw new Exception("Informe um id.");

            var produto = await GetByIdAsync(productId);
            var mapperProduct = _mapper.Map<Product>(produto);
            await _productRepository.DeleteAsync(mapperProduct);
            return produto;
        }
    }
}
