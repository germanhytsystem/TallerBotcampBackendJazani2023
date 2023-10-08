using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models
{
    public class Periodtype:CoreModel<int>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }


        public virtual ICollection<Investment>? Investments { get; set; }

    }
}
