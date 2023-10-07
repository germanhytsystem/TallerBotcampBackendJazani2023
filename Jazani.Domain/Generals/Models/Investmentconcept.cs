using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models
{
    public class Investmentconcept:CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
