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

        public Task<ProductDto> GetProductsAndOptionsById(int productId)
        {
            var product = _dbContext.Products.Include(p => p.Options).FirstOrDefault(p => p.Id == productId);
            throw new NotImplementedException();
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
