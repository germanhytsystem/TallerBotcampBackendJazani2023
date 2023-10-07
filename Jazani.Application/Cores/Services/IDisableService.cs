using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Cores.Services
{
    public interface IDisableService<TDto, ID>
    {
        Task<TDto> DisabledAsync(int id);
    }
}
