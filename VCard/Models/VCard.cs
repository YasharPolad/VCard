using VCard.Repositories;

namespace VCard.Models
{
    public class Vcard : Entity
    {

        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;

        public string? QRImageString { get; set; }
    }
}
