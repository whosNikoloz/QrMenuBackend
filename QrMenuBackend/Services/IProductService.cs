using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;

namespace QrMenuBackend.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductCreateDto productcreateDto);
        Task<ProductDto> UpdateProductAsync(int productId, ProductCreateDto productDto);
        Task DeleteProductAsync(int productId);
        Task<ProductDto> GetProductsAndOptionsById(int productId);
    }
}
