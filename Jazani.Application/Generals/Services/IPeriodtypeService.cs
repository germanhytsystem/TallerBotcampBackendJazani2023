using Jazani.Application.Generals.Dtos.Miningconcessions;
using Jazani.Application.Generals.Dtos.Periodtypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IPeriodtypeService
    {
        Task<IReadOnlyList<PeriodtypeDto>> FindAllAsync();
        Task<PeriodtypeDto?> FindByIdAsync(int id);
        Task<PeriodtypeDto> CreateAsync(PeriodtypeSaveDto SaveDto);
        Task<PeriodtypeDto> EditAsync(int id, PeriodtypeSaveDto saveDto);
        Task<PeriodtypeDto> DisabledAsync(int id);
    }
}
