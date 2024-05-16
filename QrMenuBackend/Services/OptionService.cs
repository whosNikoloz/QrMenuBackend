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
    }
}
