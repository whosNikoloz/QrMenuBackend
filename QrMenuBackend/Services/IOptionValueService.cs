using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Dtos;

namespace QrMenuBackend.Services
{
    public interface IOptionValueService
    {
        Task<OptionValueDto> CreateOptionValueAsync(OptionValueCreateDto optionValuecreateDto);
        Task<OptionValueDto> GetOptionValueByIdAsync(int optionValueId);
        Task<OptionValueDto> UpdateOptionValueAsync(int optionValueId, OptionValueCreateDto optionValueCreateDto);
        Task DeleteOptionValueAsync(int optionValueId);
    }
}
