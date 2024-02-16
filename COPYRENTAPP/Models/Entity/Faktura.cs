using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatPPP.Models.Entity
{
    public class Faktura
    {
        [Key]
        public int idFakture { get; set; }

        [Required]
        public int pib { get; set; }

        [Required]
        public float cena { get; set; }

        [Required]
        public int idKupca { get; set; }

        [Required]
        public int idMasine { get; set; }

        [ForeignKey("idMasine")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Masina Masina { get; set; }

        [ForeignKey("idKupca")]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Kupac Kupac { get; set; }
    }
}
