namespace Jazani.Domain.Generals.Models
{
    public class Miningconcession
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }


        public virtual ICollection<Miningconcession>? Miningconcessions { get; set; }


    }
}
