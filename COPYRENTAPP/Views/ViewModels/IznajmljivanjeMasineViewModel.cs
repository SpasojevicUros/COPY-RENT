using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Entity;

namespace ProjekatPPP.Views.ViewModels
{
    public class IznajmljivanjeMasineViewModel
    {
        public int idMasine { get; set; }
        public List<KupacBO> listaKupaca { get; set; }
    }
}
