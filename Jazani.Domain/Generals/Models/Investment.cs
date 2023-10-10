using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models
{
    public class Investment:CoreModel<int>
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


        public virtual Investmentconcept? Investmentconcept { get; set; }
        public virtual Miningconcession? Miningconcession { get; set; }
        public virtual Periodtype? Periodtype { get; set; }
        public virtual Measureunit? Measureunit { get; set; }
        public virtual Investmenttype? Investmenttype { get; set; }
        public virtual Holder? Holder { get; set; }

    }
}
