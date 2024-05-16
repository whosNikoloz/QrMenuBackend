using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;

namespace QrMenuBackend.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductCreateDto productcreateDto);
        Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto);
        Task DeleteProductAsync(int productId);
    }
}
