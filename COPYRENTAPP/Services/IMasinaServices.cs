using ProjekatPPP.Models.BO;

namespace ProjekatPPP.Services
{
    public interface IMasinaServices
    {
        List<MasinaBO> GetAll();
        MasinaBO GetById(int id);
        MasinaBO IzdajMasinu(int idKupca, int idMasine);
        MasinaBO Create(MasinaBO novaMasina);
        MasinaBO Update(MasinaBO izmenjenaMasina);
        void Delete(MasinaBO masinaZaBrisanje);
        void VratiMasinu(MasinaBO masinaZaVracanje);
    }
}
