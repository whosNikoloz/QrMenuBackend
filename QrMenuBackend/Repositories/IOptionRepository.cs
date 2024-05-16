﻿using QrMenuBackend.Dtos.Create;
using QrMenuBackend.Dtos;

namespace QrMenuBackend.Repositories
{
    public interface IOptionRepository
    {
        Task<OptionDto> CreateOptionAsync(OptionCreateDto optioncreateDto);
        Task<OptionDto> GetOptionByIdAsync(int optionId);
        Task<List<OptionDto>> GetAllOptionsAsync();
        Task<OptionDto> UpdateOptionAsync(int optionId, OptionCreateDto optionDto);
        Task DeleteOptionAsync(int optionId);
    }
}
