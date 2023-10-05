using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Generals.Models
{
    public class LiabilitieType
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Categoryid { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Year { get; set; }
        public bool State { get; set; }

    }
}
