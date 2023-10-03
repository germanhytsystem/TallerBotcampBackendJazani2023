using System;
namespace Jazani.Domain.Admins.Models
{

    public class Liabilitie
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

