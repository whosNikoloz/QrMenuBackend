using AutoMapper;
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
    }
}
