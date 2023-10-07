namespace Jazani.Domain.Generals.Models
{
    public class Holder
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string? Maidenname { get; set; }
        public char? Districtid { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

       // public virtual ICollection<Liabilitie>? Liabilities { get; set; }


        public virtual Investment? Investment { get; set; }
    }
}
