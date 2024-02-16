using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Maper;
using ProjekatPPP.Repository;

namespace ProjekatPPP.Services
{
    public class MasinaService : IMasinaServices
    {
        private readonly IMasinaRepository _masinaRepository;

        public MasinaService(IMasinaRepository masinaRepository)
        {
            _masinaRepository = masinaRepository;
        }

        public MasinaBO Create(MasinaBO novaMasina)
        {
            var masina = novaMasina.ConvertToEntity();
            var kreiranaMasina = _masinaRepository.Create(masina).ConvertToBO();

            return kreiranaMasina;
        }

        public void Delete(MasinaBO masinaZaBrisanje)
        {
            _masinaRepository.Delete(masinaZaBrisanje.ConvertToEntity());
        }

        public List<MasinaBO> GetAll()
        {
            var masineBO = _masinaRepository.GetAll().Select(x => x.ConvertToBO()).ToList();
            return masineBO;
        }

        public MasinaBO GetById(int id)
        {
            var masina = _masinaRepository.FindByCondition(x => x.idMasine == id).Select(x => x.ConvertToBO()).FirstOrDefault();
            return masina;
        }

        public MasinaBO IzdajMasinu(int idKupca, int idMasine)
        {
            var updateIznajmljivanja = _masinaRepository.IzdajMasinu(idKupca, idMasine).ConvertToBO();

            return updateIznajmljivanja;
        }

        public MasinaBO Update(MasinaBO izmenjenaMasina)
        {
            var masina = izmenjenaMasina.ConvertToEntity();
            var updateMasine = _masinaRepository.Update(masina).ConvertToBO();

            return updateMasine;
        }

        public void VratiMasinu(MasinaBO masinaZaVracanje)
        {
            var masina = masinaZaVracanje.ConvertToEntity();
            _masinaRepository.VratiMasinu(masina);
        }
    }
}
