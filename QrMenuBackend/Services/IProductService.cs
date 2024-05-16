using QrMenuBackend.Dtos;

namespace QrMenuBackend.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto);
        Task DeleteProductAsync(int productId);
    }
}
