using System;
namespace Jazani.Application.Admins.Dtos.Liabilities
{
	public class LiabilitieDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int Categoryid { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public int Year { get; set; }
        public bool State { get; set; }
    }
}

