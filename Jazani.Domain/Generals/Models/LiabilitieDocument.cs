namespace Jazani.Domain.Generals.Models
{
    public class LiabilitieDocument
    {
        public int DocumentId { get; set; }
        public int liabilitiesid { get; set; }
        public int Folios { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual Liabilitie? Liabilitie { get; set; }
    }
}
