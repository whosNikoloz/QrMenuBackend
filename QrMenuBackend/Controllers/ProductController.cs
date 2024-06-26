﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Services;

namespace QrMenuBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); // Return status code 200 (OK) with product list
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound(); // Return status code 404 (Not Found)
            }

            return Ok(product); // Return status code 200 (OK) with product details
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productcreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            var createdProduct = await _productService.CreateProductAsync(productcreateDto);
            if(createdProduct != null)
            {
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct); 
            }
            return BadRequest(); // Return status code 400 (Bad Request) if product creation failed
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            try
            {
                var product = await _productService.UpdateProductAsync(id, productDto);
                return Ok(product);
            }
            catch (DbUpdateConcurrencyException) // Handle optimistic concurrency conflicts
            {
                if (!ProductExists(id))
                {
                    return NotFound(); // Return status code 404 (Not Found) if product not found
                }
                else
                {
                    return BadRequest("Concurrency conflict occurred while updating the product.");
                }
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent(); // Return status code 204 (No Content) on successful deletion
        }

        private bool ProductExists(int id)
        {
            return _productService.GetProductByIdAsync(id) != null;
        }



        // GET: api/Products/5/Options
        [HttpGet("{id}/Options")]
        public async Task<IActionResult> GetProductOptions(int id)
        {
            var product = await _productService.GetProductsAndOptionsById(id);

            if (product == null)
            {
                return NotFound(); // Return status code 404 (Not Found)
            }

            return Ok(product); // Return status code 200 (OK) with product details
        }
        [HttpGet("{id}/OptionsAndValues")]
        public async Task<IActionResult> GetProductOptionsAndValues(int id)
        {
            var product = await _productService.GetProductWithOptionsAndValuesById(id);

            if (product == null)
            {
                return NotFound(); // Return status code 404 (Not Found)
            }

            return Ok(product); // Return status code 200 (OK) with product details
        }
    }
}
