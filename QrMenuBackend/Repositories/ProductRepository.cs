using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Data;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Models;

namespace QrMenuBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto productcreateDto)
        {
            var product = _mapper.Map<ProductCreateDto, Product>(productcreateDto);

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            var productDto = _mapper.Map<Product, ProductDto>(product);
            return productDto;
        }

        public Task DeleteProductAsync(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            _dbContext.Products.Remove(product);
            return _dbContext.SaveChangesAsync();
        }

        public Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = _dbContext.Products.Select(product => new ProductDto
            {
                Id = product.Id,
                Name_En = product.Name_En,
                Name_Ka = product.Name_Ka,
                Description_En = product.Description_En,
                Description_Ka = product.Description_Ka,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Group_Id = product.Group_Id
            });
            
            return products.ToListAsync();
        }

        public Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = _dbContext.Products.Find(productId);

            if(product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            var productDto = _mapper.Map<Product, ProductDto>(product);
            return Task.FromResult(productDto);
        }

        public async Task<ProductDto> GetProductsAndOptionsById(int productId)
        {
            var product = await _dbContext.Products.Include(p => p.Options).FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            var productDto = _mapper.Map<Product, ProductDto>(product);
            return productDto;
        }

        public async Task<ProductDto> GetProductWithOptionsAndValuesById(int productId)
        {
            // Retrieve the product with options and option values
            var product = await _dbContext.Products
                .Include(p => p.Options)  // Include the related Options
                    .ThenInclude(o => o.OptionValues)  // Include the OptionValues for each Option
                .FirstOrDefaultAsync(p => p.Id == productId);

            // If the product with the specified ID is not found, throw an exception
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            // Map the retrieved 'product' entity to a 'ProductDto'
            var productDto = _mapper.Map<Product, ProductDto>(product);

            // Map Options and their OptionValues to DTOs (if Options collection is not null)
            if (product.Options != null)
            {
                productDto.Options = _mapper.Map<List<OptionDto>>(product.Options);
            }
            else
            {
                productDto.Options = new List<OptionDto>(); // Initialize as empty list if Options is null
            }

            // Return the mapped 'ProductDto'
            return productDto;
        }


        public async Task<ProductDto> UpdateProductAsync(int productId, ProductCreateDto productcreateDto)
        {
            var product = _dbContext.Products.Find(productId);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            product = _mapper.Map<ProductCreateDto, Product>(productcreateDto);
            await _dbContext.SaveChangesAsync();

            var productDto = _mapper.Map<Product, ProductDto>(product);
            return productDto;
        }
    }
}
