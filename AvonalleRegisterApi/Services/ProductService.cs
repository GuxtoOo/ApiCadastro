using AutoMapper;
using AvonalleRegisterApi.Domain.Models;
using AvonalleRegisterApi.DTOs;
using AvonalleRegisterApi.Infrastructure.Repositories;
using AvonalleRegisterApi.Services.Interfaces;

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

        public async Task<ProductDto> PostAsync(ProductDto model)
        {
            if (model == null)
                throw new Exception("É preciso conter um produto.");

            var mappingModel = _mapper.Map<Product>(model);
            var response = await _productRepository.PostAsync(mappingModel);
            return _mapper.Map<ProductDto>(response);
        }
        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            if (productId.Equals(0) || productId == null)
                throw new Exception("Informe um id.");

            var response = await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductDto>(response);
        }

    }
}
