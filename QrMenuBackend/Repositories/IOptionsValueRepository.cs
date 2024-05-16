using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Dtos;

namespace QrMenuBackend.Repositories
{
    public interface IOptionsValueRepository
    {
        Task<OptionValueDto> CreateOptionValueAsync(OptionValueCreateDto optionValuecreateDto);
        Task<OptionValueDto> GetOptionValueByIdAsync(int optionValueId);
        Task<OptionValueDto> UpdateOptionValueAsync(int optionValueId, OptionValueCreateDto optionValueCreateDto);
        Task DeleteOptionValueAsync(int optionValueId);
    }
}
