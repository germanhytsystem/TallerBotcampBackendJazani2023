using Jazani.Application.Generals.Dtos.Liabilities;

namespace Jazani.Application.Generals.Dtos.LiabilitieDocuments
{
    public class LiabilitieDocumentDto
    {
        public int DocumentId { get; set; }
        public LiabilitieSimpleDto? Liabilitie { get; set; }
        public int Folios { get; set; } = default!;
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

    }
}
