using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Investments
{
    public class InvestmentSaveDto
    {
        public string? Description { get; set; }
        public int? Year { get; set; }
        public string? Monthname { get; set; }
        public int? Miningconcessionid { get; set; }
        public int? Investmenttypeid { get; set; }
        public int? Periodtypeid { get; set; }
        public int? Measureunitid { get; set; }
        public int? Holderid { get; set; }
        public int? Investmentconceptid { get; set; }
    }
}
