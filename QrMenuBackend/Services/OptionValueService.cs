using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Repositories;

namespace QrMenuBackend.Services
{
    public class OptionValueService : IOptionValueService
    {
        private readonly IOptionsValueRepository _optionsValueRepository;

        public OptionValueService(IOptionsValueRepository optionsValueRepository)
        {
            _optionsValueRepository = optionsValueRepository;
        }
        public Task<OptionValueDto> CreateOptionValueAsync(OptionValueCreateDto optionValuecreateDto)
        {
            return _optionsValueRepository.CreateOptionValueAsync(optionValuecreateDto);
        }

        public Task DeleteOptionValueAsync(int optionValueId)
        {
            return _optionsValueRepository.DeleteOptionValueAsync(optionValueId);
        }


        public Task<OptionValueDto> GetOptionValueByIdAsync(int optionValueId)
        {
            return _optionsValueRepository.GetOptionValueByIdAsync(optionValueId);
        }

        public Task<OptionValueDto> UpdateOptionValueAsync(int optionValueId, OptionValueCreateDto optionValueCreateDto)
        {
            return _optionsValueRepository.UpdateOptionValueAsync(optionValueId, optionValueCreateDto);
        }
    }
}
