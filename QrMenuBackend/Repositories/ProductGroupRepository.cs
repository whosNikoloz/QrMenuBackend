using QrMenuBackend.Data;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Models;

namespace QrMenuBackend.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductGroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductGroupDto> CreateProductGroupAsync(ProductGroupCreateDto productGroupCreateDto)
        {
            var productGroup = new ProductGroup
            {
                Name_En = productGroupCreateDto.Name_En,
                Name_Ka = productGroupCreateDto.Name_Ka
            };

            _dbContext.ProductGroups.Add(productGroup);
            await _dbContext.SaveChangesAsync();

            ProductGroupDto productGroupDto = new ProductGroupDto
            {
                Id = productGroup.Id,
                Name_En = productGroup.Name_En,
                Name_Ka = productGroup.Name_Ka
            };

            return productGroupDto;
        }

        public async Task DeleteProductGroupAsync(int productgroupId)
        {

            var productGroup = await _dbContext.ProductGroups.FindAsync(productgroupId);
            if (productGroup == null)
            {
                throw new KeyNotFoundException("Product group not found"); // Throw exception for not found
            }
            _dbContext.ProductGroups.Remove(productGroup);
            await _dbContext.SaveChangesAsync();
        }

        public Task<IEnumerable<ProductGroupDto>> GetAllGroupAsync()
        {
            var productGroups = _dbContext.ProductGroups.Select(productGroup => new ProductGroupDto
            {
                Id = productGroup.Id,
                Name_En = productGroup.Name_En,
                Name_Ka = productGroup.Name_Ka
            });

            return Task.FromResult<IEnumerable<ProductGroupDto>>(productGroups);
        }

        public Task<ProductGroupDto> GetProductGroupByIdAsync(int productgroupId)
        {
            var productGroup = _dbContext.ProductGroups.Find(productgroupId);
            if (productGroup != null)
            {
                ProductGroupDto productGroupDto = new ProductGroupDto
                {
                    Id = productGroup.Id,
                    Name_En = productGroup.Name_En,
                    Name_Ka = productGroup.Name_Ka
                };
                return Task.FromResult(productGroupDto);
            }
            throw new NotImplementedException();
        }

        public Task<ProductGroupDto> UpdateProductGroupAsync(int productgroupId, ProductGroupCreateDto productgroupDto)
        {
            var productGroup = _dbContext.ProductGroups.Find(productgroupId);
            if (productGroup != null)
            {
                productGroup.Name_En = productgroupDto.Name_En;
                productGroup.Name_Ka = productgroupDto.Name_Ka;
                _dbContext.ProductGroups.Update(productGroup);
                _dbContext.SaveChanges();
            }
            if(productGroup == null)
            {
                throw new KeyNotFoundException("Product group not found"); // Throw exception for not found
            }

            ProductGroupDto productGroupDto = new ProductGroupDto
            {
                Id = productGroup.Id,
                Name_En = productGroup.Name_En,
                Name_Ka = productGroup.Name_Ka
            };

            return Task.FromResult(productGroupDto);
        }
    }
}
