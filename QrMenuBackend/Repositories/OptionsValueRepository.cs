using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<OptionValueDto> CreateOptionValueAsync(OptionValueCreateDto optionValuecreateDto)
        {
            var OptionValue = _mapper.Map<OptionValueCreateDto, OptionValue>(optionValuecreateDto);
            _context.OptionValues.Add(OptionValue);
            await _context.SaveChangesAsync();
            return _mapper.Map<OptionValue, OptionValueDto>(OptionValue);
        }

        public async Task DeleteOptionValueAsync(int optionValueId)
        {
            var optionValue = _context.OptionValues.Find(optionValueId);
            if (optionValue == null)
            {
                throw new KeyNotFoundException("OptionValue not found");
            }
            _context.OptionValues.Remove(optionValue);
            await _context.SaveChangesAsync();
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

        public async Task<OptionValueDto> UpdateOptionValueAsync(int optionValueId, OptionValueCreateDto optionValueCreateDto)
        {
            var optionValue = _context.OptionValues.Find(optionValueId);
            if (optionValue == null)
            {
                throw new KeyNotFoundException("OptionValue not found");
            }
            _mapper.Map(optionValueCreateDto, optionValue);
            _context.OptionValues.Update(optionValue);
            await _context.SaveChangesAsync();
            return _mapper.Map<OptionValue, OptionValueDto>(optionValue);
        }
    }
}
