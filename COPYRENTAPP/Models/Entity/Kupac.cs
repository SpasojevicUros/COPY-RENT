using System.ComponentModel.DataAnnotations;

namespace ProjekatPPP.Models.Entity
{
    public class Kupac
    {
        [Key]
        public int idKupca { get; set; }

        [Required]
        public string imeFirme { get; set; }

        [Required]
        public int bankovniRacun { get; set; }

        [Required]
        public int pib { get; set; }
    }
}
