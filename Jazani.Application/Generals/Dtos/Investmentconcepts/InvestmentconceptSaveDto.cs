using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Investmentconcepts
{
    public class InvestmentconceptSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
