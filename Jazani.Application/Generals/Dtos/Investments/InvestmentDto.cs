using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Application.Generals.Dtos.Investmentconcepts;
using Jazani.Application.Generals.Dtos.Investmenttypes;
using Jazani.Application.Generals.Dtos.Measureunits.Profiles;
using Jazani.Application.Generals.Dtos.Miningconcessions;
using Jazani.Application.Generals.Dtos.Periodtypes;

namespace Jazani.Application.Generals.Dtos.Investments
{
    public class InvestmentDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? Year { get; set; }
        public string? Monthname { get; set; }
        //public int Miningconcessionid { get; set; }
        public MiningconcessionSimpleDto? Miningconcession { get; set; }
        //public int Investmenttypeid { get; set; }
        public InvestmenttypeSimpleDto? investmenttype { get; set; }
        //public int Periodtypeid { get; set; }
        public PeriodtypeSimpleDto? Periodtype { get; set; }
        //public int Measureunitid { get; set; }
        public MeasureunitSimpleDto? Measureunit { get; set; }
        //public int Holderid { get; set; }
        public HolderSimpleDto? Holder { get; set; }
        //public int Investmentconceptid { get; set; }
        public InvestmentconceptSimpleDto? Investmentconcept { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
