using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Measureunits.Profiles
{
    public class MeasureunitDto
    {
        public int Id { get; set; }
        public int? Measureunitid { get; set; }
        public string? Name { get; set; } = default!;
        public string ?Symbol { get; set; }
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
