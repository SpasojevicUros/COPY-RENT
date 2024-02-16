using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Maper;
using ProjekatPPP.Repository;

namespace ProjekatPPP.Services
{
    public class FakturaService : IFakturaService
    {
        private readonly IFakturaRepository _fakturaRepository;

        public FakturaService(IFakturaRepository fakturaRepository)
        {
            _fakturaRepository = fakturaRepository;
        }

        public FakturaBO Create(FakturaBO novaFaktura)
        {
            var faktura = novaFaktura.ConvertToEntity();
            var kreiranaFaktura = _fakturaRepository.Create(faktura).ConvertToBO();

            return kreiranaFaktura;
        }

        public void Delete(FakturaBO fakturaZaBrisanje)
        {
            _fakturaRepository.Delete(fakturaZaBrisanje.ConvertToEntity());
        }

        public List<FakturaBO> GetAll()
        {
            var fakturaBO = _fakturaRepository.GetAll().Select(x => x.ConvertToBO()).ToList();
            return fakturaBO;
        }

        public FakturaBO Update(FakturaBO izmenjenaFaktura)
        {
            var faktura = izmenjenaFaktura.ConvertToEntity();
            var updateFakture = _fakturaRepository.Update(faktura).ConvertToBO();

            return updateFakture;
        }

        FakturaBO IFakturaService.GetById(int id)
        {
            var faktura = _fakturaRepository.FindByCondition(x => x.idFakture == id).Select(x => x.ConvertToBO()).FirstOrDefault();
            return faktura; 
        }
    }
}
