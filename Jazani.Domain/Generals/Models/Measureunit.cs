using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Generals.Models
{
    public class Measureunit:CoreModel<int>
    {
        public int? Measureunitid { get; set; }
        public string? Name { get; set; } = default!;
        public string? Symbol { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Investment>? Investments { get; set; }

    }

}
