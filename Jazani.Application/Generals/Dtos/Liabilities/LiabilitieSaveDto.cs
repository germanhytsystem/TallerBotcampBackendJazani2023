namespace Jazani.Application.Generals.Dtos.Liabilities
{
    public class LiabilitieSaveDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Year { get; set; }
        public int Categoryid { get; set; }
        public int HolderId { get; set; }
    }
}
