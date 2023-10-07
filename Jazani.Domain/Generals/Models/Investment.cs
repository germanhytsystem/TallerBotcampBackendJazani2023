using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Generals.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Miningconcessionid { get; set; }
        public int Investmenttypeid { get; set; }
        public int Periodtypeid { get; set; }
        public int Measureunitid { get; set; }
        public int Holderid { get; set; }
        public int Investmentconceptid { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }


        //public virtual ICollection<>? LiabilitieDocuments { get; set; }

       
        public virtual Miningconcession? Miningconcession { get; set; }
        //public virtual Investmenttype? Investmenttype { get; set; }
        //public virtual Periodtype? Periodtype { get; set; }
        //public virtual Measureunit? Measureunit { get; set; }
        //public virtual Holder? Holder { get; set; }
        //public virtual Investmentconcept? Investmentconcept { get; set;}

    }
}
