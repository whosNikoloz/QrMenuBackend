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

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto productcreateDto)
        {
            var product = new Product
            {
                Name_En = productcreateDto.Name_En,
                Name_Ka = productcreateDto.Name_Ka,
                Description_En = productcreateDto.Description_En,
                Description_Ka = productcreateDto.Description_Ka,
                ImageUrl = productcreateDto.ImageUrl,
                Discount = productcreateDto.Discount,
                Price = productcreateDto.Price,
                Group_Id = productcreateDto.Group_Id
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            ProductDto productDto = new ProductDto
            {
                Id = product.Id,
                Name_En = product.Name_En,
                Name_Ka = product.Name_Ka,
                Description_En = product.Description_En,
                Description_Ka = product.Description_Ka,
                ImageUrl = product.ImageUrl,
                Discount = product.Discount,
                Price = product.Price,
                Group_Id = product.Group_Id
            };

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
