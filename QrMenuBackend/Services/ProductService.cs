using QrMenuBackend.Dtos;
using QrMenuBackend.Repositories;

namespace QrMenuBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            return await _productRepository.CreateProductAsync(productDto);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto)
        {
            return await _productRepository.UpdateProductAsync(productId, productDto);
        }
    }
}
