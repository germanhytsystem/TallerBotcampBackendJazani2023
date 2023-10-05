namespace Jazani.Application.Generals.Dtos.Holders
{
    public class HolderSaveDto
    {
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string? Maidenname { get; set; }
        public char? Districtid { get; set; }
    }
}
