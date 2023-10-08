using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models
{
    public class Miningconcession:CoreModel<int>
    {
        public string? Code { get; set; }
        public string? Name { get; set; } = default!;
        public string? Description { get; set; }


        public virtual ICollection<Investment>? Investments { get; set; }

    }
}
