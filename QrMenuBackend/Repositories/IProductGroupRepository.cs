using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;

namespace QrMenuBackend.Repositories
{
    public interface IProductGroupRepository
    {
        Task<ProductGroupDto> GetProductGroupByIdAsync(int productgroupId);
        Task<IEnumerable<ProductGroupDto>> GetAllGroupAsync();
        Task<ProductGroupDto> CreateProductGroupAsync(ProductGroupCreateDto productGroupCreateDto);
        Task<ProductGroupDto> UpdateProductGroupAsync(int productgroupId, ProductGroupCreateDto productgroupDto);
        Task DeleteProductGroupAsync(int productgroupId);
    }
}
