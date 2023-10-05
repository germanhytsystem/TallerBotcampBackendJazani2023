namespace Jazani.Application.Generals.Dtos.Holders
{
    public class HolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string? Maidenname { get; set; }
        public char? Districtid { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
