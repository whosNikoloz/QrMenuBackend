using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Data;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Models;

namespace QrMenuBackend.Repositories
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductGroupRepository(AppDbContext dbContext, IMapper mapper, IProductRepository productRepository)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _productRepository = productRepository;
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
            var productGroup = await  _dbContext.ProductGroups.Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == productgroupId);
            if (productGroup == null)
            {
                throw new KeyNotFoundException("Product group not found"); // Throw exception for not found
            }

            if(productGroup.Products?.Count > 0)
            {
                foreach (var product in productGroup.Products)
                {
                    await _productRepository.DeleteProductAsync(product.Id);
                }
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
                Name_Ka = productGroup.Name_Ka,
                ImageUrl = productGroup.ImageUrl
            });

            return Task.FromResult<IEnumerable<ProductGroupDto>>(productGroups);
        }

        public  Task<List<ProductGroupDto>> GetAllWithProductsAsync()
        {
            try
            {
                var productGroups = _dbContext.ProductGroups
                                    .Include(p => p.Products)
                                        .ThenInclude(op => op.Options)
                                            .ThenInclude(vl => vl.OptionValues)
                                    .ToList();

                var productGroupsDto = _mapper.Map<List<ProductGroup>, List<ProductGroupDto>>(productGroups);

                if(productGroupsDto != null)
                {
                    return Task.FromResult(productGroupsDto);
                }
                throw new KeyNotFoundException("Product group not found");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public Task<ProductGroupDto> GetProductGroupByIdAsync(int productgroupId)
        {
            var productGroup = _dbContext.ProductGroups.Find(productgroupId);

            if (productGroup != null)
            {
                return Task.FromResult(_mapper.Map<ProductGroup, ProductGroupDto>(productGroup));
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
