using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Measureunits.Profiles
{
    public class MeasureunitSimpleDto
    {
        public int Id { get; set; }
        public int? Measureunitid { get; set; }
        public string? Name { get; set; } = default!;
    }
}
