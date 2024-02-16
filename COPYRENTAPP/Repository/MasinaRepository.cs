using ProjekatPPP.Data;
using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Entity;
using ProjekatPPP.Repository.Base;

namespace ProjekatPPP.Repository
{
    public class MasinaRepository : BaseRepository<Masina>, IMasinaRepository
    {
        private readonly ProjekatPPPContext _context;

        public MasinaRepository(ProjekatPPPContext context) : base(context)
        {
            _context = context;
        }

        public Masina IzdajMasinu(int idKupca, int idMasine)
        {
            var masina = FindByCondition(m => m.idMasine == idMasine).FirstOrDefault();
            if (masina == null)
            {
                //nije pronadjena masina
            }
            masina.izdataKupcu = idKupca;
            var izmenjenaMasina = Set.Update(masina).Entity;
            _context.SaveChanges();
            return izmenjenaMasina;
        }

        public void VratiMasinu(Masina masinaZaVracanje)
        {
            var masina = FindByCondition(a => a.idMasine == masinaZaVracanje.idMasine).FirstOrDefault();

            if (masina.izdataKupcu != null)
            {
                masina.izdataKupcu = 0;
                var vracenaMasina = Set.Update(masina);
                _context.SaveChanges();
            }
        }
    }
}
