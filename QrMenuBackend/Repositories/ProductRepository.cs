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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {

            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }


        public async Task<ProductDto> UpdateProductAsync(int productId, ProductDto productDto)
        {
            throw new NotImplementedException();
        }
       
    }
}
