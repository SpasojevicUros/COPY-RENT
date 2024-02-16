using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Entity;
using ProjekatPPP.Repository.Base;

namespace ProjekatPPP.Repository
{
    public interface IMasinaRepository : IBaseRepository<Masina>
    {
        Masina IzdajMasinu(int idKupca, int idMasine);

        void VratiMasinu(Masina masinaZaVracanje);
    }
}
