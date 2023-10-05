﻿using Jazani.Application.Generals.Dtos.Liabilities;

namespace Jazani.Application.Generals.Services
{
    public interface ILiabilitieService
    {
        Task<IReadOnlyList<LiabilitieDto>> FindAllAsync();
        Task<LiabilitieDto?> FindByIdAsync(int id);
        Task<LiabilitieDto> CreateAsync(LiabilitieSaveDto officeSaveDto);
        Task<LiabilitieDto> EditAsync(int id, LiabilitieSaveDto officeSaveDto);
        Task<LiabilitieDto> DisabledAsync(int id);
    }
}
