using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Dtos;

namespace QrMenuBackend.Services
{
    public interface IOptionService
    {
        Task<OptionDto> CreateOptionAsync(OptionCreateDto optioncreateDto);
    }
}
