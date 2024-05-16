using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Services;

namespace QrMenuBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionValueController : ControllerBase
    {
        private readonly IOptionValueService _optionValueService;
        public OptionValueController(IOptionValueService optionvalueService)
        {
            _optionValueService = optionvalueService;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateOptionValue([FromBody] OptionValueCreateDto optionValueCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            var createdOptionValue = await _optionValueService.CreateOptionValueAsync(optionValueCreateDto);
            if (createdOptionValue == null)
            {
                return BadRequest();
            }
            return Ok(createdOptionValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionValueById(int id)
        {
            var optionValue = await _optionValueService.GetOptionValueByIdAsync(id);

            if (optionValue == null)
            {
                return NotFound(); // Return status code 404 (Not Found)
            }

            return Ok(optionValue); // Return status code 200 (OK) with product details
        }
        
        [HttpPut("{OptionValueId}")]
        public async Task<IActionResult> UpdateOptionValue(int OptionValueId, [FromBody] OptionValueCreateDto optionValueCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            var updatedOptionValue = await _optionValueService.UpdateOptionValueAsync(OptionValueId, optionValueCreateDto);
            if (updatedOptionValue == null)
            {
                return BadRequest();
            }
            return Ok(updatedOptionValue);
        }
        [HttpDelete("{OptionValueId}")]
        public async Task<IActionResult> DeleteOptionValue(int OptionValueId)
        {
            await _optionValueService.DeleteOptionValueAsync(OptionValueId);
            return Ok(); 
        }
    }
}
