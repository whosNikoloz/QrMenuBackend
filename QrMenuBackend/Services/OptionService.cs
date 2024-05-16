using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Repositories;

namespace QrMenuBackend.Services
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;

        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public Task<OptionDto> CreateOptionAsync(OptionCreateDto optioncreateDto)
        {
            return _optionRepository.CreateOptionAsync(optioncreateDto);
        }

        public Task DeleteOptionAsync(int optionId)
        {
            return _optionRepository.DeleteOptionAsync(optionId);
        }

        public Task<List<OptionDto>> GetAllOptionsAsync()
        {
            return _optionRepository.GetAllOptionsAsync();
        }

        public Task<OptionDto> GetOptionByIdAsync(int optionId)
        {
            return _optionRepository.GetOptionByIdAsync(optionId);
        }

        public Task<OptionDto> UpdateOptionAsync(int optionId, OptionCreateDto optionDto)
        {
            return _optionRepository.UpdateOptionAsync(optionId, optionDto);
        }
    }
}
