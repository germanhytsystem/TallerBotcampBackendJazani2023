using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Measureunits.Profiles
{
    public class MeasureunitSaveDto
    {
        public int? Measureunitid { get; set; }
        public string? Name { get; set; } = default!;
        public string? Symbol { get; set; }
        public string? Description { get; set; }
    }
}
