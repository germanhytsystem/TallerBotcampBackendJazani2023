using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Miningconcessions
{
    public class MiningconcessionSaveDto
    {
        public int Code { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
