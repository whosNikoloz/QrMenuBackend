using AutoMapper;
using QrMenuBackend.Data;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Models;

namespace QrMenuBackend.Repositories
{
    public class OptionsValueRepository : IOptionsValueRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OptionsValueRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public Task<OptionValueDto> CreateOptionValueAsync(OptionValueCreateDto optionValuecreateDto)
        {
            var OptionValue = _mapper.Map<OptionValueCreateDto, OptionValue>(optionValuecreateDto);
            _context.OptionValues.Add(OptionValue);
            _context.SaveChangesAsync();
            return Task.FromResult(_mapper.Map<OptionValue, OptionValueDto>(OptionValue));
        }

        public Task DeleteOptionValueAsync(int optionValueId)
        {

            var optionValue = _context.OptionValues.Find(optionValueId);
            if (optionValue == null)
            {
                throw new KeyNotFoundException("OptionValue not found");
            }
            _context.OptionValues.Remove(optionValue);
            return _context.SaveChangesAsync();
        }

        public Task<OptionValueDto> GetOptionValueByIdAsync(int optionValueId)
        {
            var optionValue = _context.OptionValues.Find(optionValueId);
            if (optionValue == null)
            {
                throw new KeyNotFoundException("OptionValue not found");
            }
            return Task.FromResult(_mapper.Map<OptionValue, OptionValueDto>(optionValue));
        }

        public Task<OptionValueDto> UpdateOptionValueAsync(int optionValueId, OptionValueCreateDto optionValueCreateDto)
        {
            var optionValue = _context.OptionValues.Find(optionValueId);
            if (optionValue == null)
            {
                throw new KeyNotFoundException("OptionValue not found");
            }
            _mapper.Map(optionValueCreateDto, optionValue);
            _context.OptionValues.Update(optionValue);
            _context.SaveChangesAsync();
            return Task.FromResult(_mapper.Map<OptionValue, OptionValueDto>(optionValue));
        }
    }
}
