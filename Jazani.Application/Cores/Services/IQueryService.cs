using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Cores.Services
{
    public interface IQueryService<TDto, ID>
    {
        Task<IReadOnlyList<TDto>> FindAllAsync();
        Task<TDto?> FindByIdAsync(int id);
    }
}
