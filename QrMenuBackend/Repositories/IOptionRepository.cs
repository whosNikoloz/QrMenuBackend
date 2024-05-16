using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Dtos;

namespace QrMenuBackend.Repositories
{
    public interface IOptionRepository
    {
        Task<OptionDto> CreateOptionAsync(OptionCreateDto optioncreateDto);
    }
}
