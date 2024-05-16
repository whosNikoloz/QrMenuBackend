using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Services;

namespace QrMenuBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService _productGroupService;

        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductGroup([FromBody] ProductGroupCreateDto productGroupCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            var createdProductGroup = await _productGroupService.CreateProductgroupAsync(productGroupCreateDto);
            if(createdProductGroup == null)
            {
                return BadRequest();
            }
            return Ok(createdProductGroup);
        }

        [HttpGet("{GroupId}")]
        public async Task<IActionResult> GetProductGroupById(int GroupId)
        {
            var productGroup = await _productGroupService.GetProductGroupByIdAsync(GroupId);
            if(productGroup == null)
            {
                return NotFound();
            }
            return Ok(productGroup);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var productGroups = await _productGroupService.GetAllGroupsAsync();
            return Ok(productGroups);
        }

        [HttpDelete("{GroupId}")]
        public async Task<IActionResult> DeleteProductGroup(int GroupId)
        {
            try
            {
                await _productGroupService.DeleteProductGroupAsync(GroupId);
                return Ok(); // Return 200 OK on successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [HttpPut("{GroupId}")]
        public async Task<IActionResult> UpdateProductGroup(int GroupId, [FromBody] ProductGroupCreateDto productGroupCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }
            try
            {
                var updatedProductGroup = await _productGroupService.UpdateProductGroupAsync(GroupId, productGroupCreateDto);

                return Ok(updatedProductGroup); // Return 200 OK on successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("all-with-products")]
        public async Task<ActionResult<List<ProductGroupDto>>> GetAllWithProducts()
        {
            var productGroupsDto = await _productGroupService.GetAllWithProductsAsync();
            return Ok(productGroupsDto);
        }
    }
}
