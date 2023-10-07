using Jazani.Application.Generals.Dtos.Liabilities;
using Jazani.Application.Generals.Dtos.Miningconcessions;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IMiningconcessionService
    {
        Task<IReadOnlyList<MiningconcessionDto>> FindAllAsync();
        Task<MiningconcessionDto?> FindByIdAsync(int id);
        Task<MiningconcessionDto> CreateAsync(MiningconcessionSaveDto miningconcessionSaveDto);
        Task<MiningconcessionDto> EditAsync(int id, MiningconcessionSaveDto miningconcessionSaveDto);
        Task<MiningconcessionDto> DisabledAsync(int id);
    }
}
