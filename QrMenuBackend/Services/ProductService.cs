using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
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

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto productcreateDto)
        {
            return await _productRepository.CreateProductAsync(productcreateDto);
        }

        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<ProductDto> GetProductsAndOptionsById(int productId)
        {
            return await _productRepository.GetProductsAndOptionsById(productId);
        }

        public async Task<ProductDto> UpdateProductAsync(int productId, ProductCreateDto productDto)
        {
            return await _productRepository.UpdateProductAsync(productId, productDto);
        }
    }
}
