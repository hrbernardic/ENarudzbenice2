using DDFramework;

namespace ENarudzbenice2.Domain.Entities
{
    public class Tim : SifarnikEntity
    {
        public string RadnoVrijeme { get; set; }
        public string KontaktBroj { get; set; }
        public string Email { get; set; }
        public string Godisnji { get; set; }
        public bool Aktivan { get; set; }
        public string AdresaDostava { get; set; }

        public Adresa Adresa { get; set; }
        public Djelatnost Djelatnost { get; set; }
    }
}
