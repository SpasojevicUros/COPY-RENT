using System.ComponentModel.DataAnnotations;

namespace ProjekatPPP.Models.Entity
{
    public class Masina
    {
        [Key]
        public int idMasine { get; set; }

        [Required]
        public string proizvodjac { get; set; }

        [Required]
        public int model { get; set; }

        [Required]
        public int brojKopija { get; set; }

        [Required]
        public float cena { get; set; }

        [Required]
        public string opis { get; set; }

        [Required]
        public int izdataKupcu { get; set; }
    }
}
