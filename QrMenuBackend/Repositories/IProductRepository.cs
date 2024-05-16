using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;

namespace QrMenuBackend.Repositories
{
    public interface IProductRepository
    {
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductCreateDto productcreateDto);
        Task<ProductDto> UpdateProductAsync(int productId, ProductCreateDto productcreateDto);
        Task DeleteProductAsync(int productId);
        Task<ProductDto> GetProductsAndOptionsById(int productId);
        Task<ProductDto> GetProductWithOptionsAndValuesById(int productId);
    }
}
