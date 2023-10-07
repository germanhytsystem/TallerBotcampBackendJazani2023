namespace Jazani.Domain.Generals.Models
{
    public class Liabilitie
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Categoryid { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Year { get; set; }
        public bool State { get; set; }
        public int HolderId { get; set; }

        public virtual ICollection<LiabilitieDocument>? LiabilitieDocuments { get; set; }

        //public virtual Holder? Holder { get; set; }
    }
}
