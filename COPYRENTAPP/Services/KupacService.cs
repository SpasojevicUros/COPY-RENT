using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Maper;
using ProjekatPPP.Repository;

namespace ProjekatPPP.Services
{
    public class KupacService : IKupacService
    {
        private readonly IKupacRepository _kupacRepository;

        public KupacService(IKupacRepository kupacRepository)
        {
            _kupacRepository = kupacRepository;
        }

        public KupacBO Create(KupacBO noviKupac)
        {
            var kupac = noviKupac.ConvertToEntity();
            var kreiranKupac = _kupacRepository.Create(kupac).ConvertToBO();

            return kreiranKupac;
        }

        public void Delete(KupacBO kupacZaBrisanje)
        {
            _kupacRepository.Delete(kupacZaBrisanje.ConvertToEntity());
        }

        public List<KupacBO> GetAll()
        {
            var kupacBO = _kupacRepository.GetAll().Select(x => x.ConvertToBO()).ToList();
            return kupacBO;
        }

        public KupacBO GetByCompanyName(string nazivFirme)
        {
            var kupac = _kupacRepository.FindByCondition(f=>f.imeFirme == nazivFirme).FirstOrDefault();
            return kupac.ConvertToBO();
        }

        public KupacBO Update(KupacBO izmenjenKupac)
        {
            var kupac = izmenjenKupac.ConvertToEntity();
            var updateKupca = _kupacRepository.Update(kupac).ConvertToBO();

            return updateKupca;
        }

        KupacBO IKupacService.GetById(int id)
        {
            var kupac = _kupacRepository.FindByCondition(x => x.idKupca == id).Select(x => x.ConvertToBO()).FirstOrDefault();
            return kupac; 
        }
    }
}
