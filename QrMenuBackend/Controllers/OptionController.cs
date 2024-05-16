using Microsoft.AspNetCore.Mvc;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Services;

namespace QrMenuBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOption([FromBody] OptionCreateDto optionCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            var createdOption = await _optionService.CreateOptionAsync(optionCreateDto);
            if (createdOption == null)
            {
                return BadRequest();
            }
            return Ok(createdOption);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(int id)
        {
            var option = await _optionService.GetOptionByIdAsync(id);

            if (option == null)
            {
                return NotFound(); // Return status code 404 (Not Found)
            }

            return Ok(option); // Return status code 200 (OK) with product details
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptions()
        {
            var options = await _optionService.GetAllOptionsAsync();
            return Ok(options); // Return status code 200 (OK) with product list
        }
        [HttpPut("{OptionId}")]
        public async Task<IActionResult> UpdateOption(int OptionId, [FromBody] OptionCreateDto optionCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return status code 400 (Bad Request) with validation errors
            }

            var updatedOption = await _optionService.UpdateOptionAsync(OptionId, optionCreateDto);
            if (updatedOption == null)
            {
                return BadRequest();
            }
            return Ok(updatedOption);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            await _optionService.DeleteOptionAsync(id);
            return Ok();
        }
    }
}
