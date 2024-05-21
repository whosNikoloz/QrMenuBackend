using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QrMenuBackend.Data;
using QrMenuBackend.Dtos;
using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Models;

namespace QrMenuBackend.Repositories
{
    public class OptionRepository : IOptionRepository
    {   
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OptionRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<OptionDto> CreateOptionAsync(OptionCreateDto optioncreateDto)
        {
            var Option = _mapper.Map<OptionCreateDto, Option>(optioncreateDto);
            _context.Options.Add(Option);
            await _context.SaveChangesAsync();

            return _mapper.Map<Option, OptionDto>(Option);
        }

        public async Task DeleteOptionAsync(int optionId)
        {
            var option = await _context.Options
                .Include(o => o.OptionValues)
                .FirstOrDefaultAsync(o => o.Id == optionId);

            if (option == null)
            {
                throw new KeyNotFoundException("Option not found");
            }

            // Remove the associated option values
            if (option.OptionValues?.Count > 0)
            {
                _context.OptionValues.RemoveRange(option.OptionValues);
            }

            // Remove the option
            _context.Options.Remove(option);

            // Save changes asynchronously
            await _context.SaveChangesAsync();
        }
        public Task<List<OptionDto>> GetAllOptionsAsync()
        {
            var options = _context.Options.Select(option => new OptionDto
            {
                Id = option.Id,
                Name_En = option.Name_En,
                Name_Ka = option.Name_Ka,
                Product_Id = option.Product_Id
            });

            return Task.FromResult(options.ToList());
        }

        public Task<OptionDto> GetOptionByIdAsync(int optionId)
        {
            var option = _context.Options.Find(optionId);
            if (option == null)
            {
                throw new KeyNotFoundException("Option not found");
            }
            return Task.FromResult(_mapper.Map<Option, OptionDto>(option));
            throw new NotImplementedException();
        }

        public Task<OptionDto> UpdateOptionAsync(int optionId, OptionCreateDto optionDto)
        {
            var option = _context.Options.Find(optionId);
            if (option == null)
            {
                throw new KeyNotFoundException("Option not found");
            }
            _mapper.Map(optionDto, option);
            _context.SaveChanges();
            return Task.FromResult(_mapper.Map<Option, OptionDto>(option));
        }
    }
}
