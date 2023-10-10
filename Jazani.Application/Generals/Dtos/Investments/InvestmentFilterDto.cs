using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Investments
{
    public class InvestmentFilterDto
    {
        public string? Description { get; set; }
        public int? Year { get; set; }
        public string? Monthname { get; set; }
    }
}
