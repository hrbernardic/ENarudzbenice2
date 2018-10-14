using System.ComponentModel.DataAnnotations.Schema;

namespace DDFramework
{
    public class SifarnikEntity : BaseEntity
    {
        public string Naziv { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sifra { get; set; }
    }
}
