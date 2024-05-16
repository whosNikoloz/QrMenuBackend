using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Models;
using QrMenuBackend.Repositories;

namespace QrMenuBackend.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IProductGroupRepository _productgroupRepository;

        public ProductGroupService(IProductGroupRepository productgroupRepository)
        {
            _productgroupRepository = productgroupRepository;
        }

        public async Task<ProductGroupDto> CreateProductgroupAsync(ProductGroupCreateDto productgroupCreateDto)
        {
            return await _productgroupRepository.CreateProductGroupAsync(productgroupCreateDto);
        }

        public async Task<ProductGroupDto> GetProductGroupByIdAsync(int productgroupId)
        {
            return await _productgroupRepository.GetProductGroupByIdAsync(productgroupId);
        }

        public async Task<IEnumerable<ProductGroupDto>> GetAllGroupsAsync()
        {
            return await _productgroupRepository.GetAllGroupAsync();
        }

        public Task<ProductGroupDto> UpdateProductGroupAsync(int productgroupId, ProductGroupCreateDto productgroupDto)
        {
            return _productgroupRepository.UpdateProductGroupAsync(productgroupId, productgroupDto);
        }

        public Task DeleteProductGroupAsync(int productgroupId)
        {
            return _productgroupRepository.DeleteProductGroupAsync(productgroupId);
        }

        public Task<List<ProductGroupDto>> GetAllWithProductsAsync()
        {
            var product = _productgroupRepository.GetAllWithProductsAsync();
            return product;
        }
    }
}
