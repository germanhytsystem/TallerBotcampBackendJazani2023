using Jazani.Application.Generals.Dtos.Holders;

namespace Jazani.Application.Generals.Dtos.Liabilities
{
    public class LiabilitieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Year { get; set; }
        public int Categoryid { get; set; }
        public HolderSimpleDto Holder { get; set; }
        //public int HolderId { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
