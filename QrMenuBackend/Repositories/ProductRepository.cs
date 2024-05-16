using Azure.Core;
using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Data;
using QrMenuBackend.Dtos;
using QrMenuBackend.Models;

namespace QrMenuBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
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
