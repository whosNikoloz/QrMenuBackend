using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;

namespace QrMenuBackend.Services
{
    public interface IProductGroupService
    {
        Task<ProductGroupDto> CreateProductgroupAsync(ProductGroupCreateDto productgroupCreateDto);
        Task<ProductGroupDto> GetProductGroupByIdAsync(int productgroupId);
        Task<IEnumerable<ProductGroupDto>> GetAllGroupsAsync();
        Task<ProductGroupDto> UpdateProductGroupAsync(int productgroupId, ProductGroupCreateDto productgroupDto);
        Task DeleteProductGroupAsync(int productgroupId);
    }
}
