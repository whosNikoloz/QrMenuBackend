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

        //[HttpGet("{OptionId}")]
        //public async Task<IActionResult> GetOptionById(int OptionId)
        //{
        //    var option = await _optionService.GetOptionByIdAsync(OptionId);
        //    if (option == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(option);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllOptions()
        //{
        //    var options = await _optionService.GetAllOptionsAsync();
        //    return Ok(options);
        //}

        //[HttpDelete("{OptionId}")]
        //public async Task<IActionResult> DeleteOption(int OptionId)
        //{
        //    try
        //    {
        //        await _optionService.DeleteOptionAsync(OptionId);
        //        return Ok(); // Return 200 OK on successful deletion
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message); // Return 500 Internal Server Error on exception
        //    }
        //}
    }
}
