using ProjekatPPP.Models.BO;

namespace ProjekatPPP.Services
{
    public interface IFakturaService
    {
        List<FakturaBO> GetAll();
        FakturaBO GetById(int id);
        FakturaBO Create(FakturaBO novaFaktura);
        FakturaBO Update(FakturaBO izmenjenaFaktura);
        void Delete(FakturaBO fakturaZaBrisanje);
    }
}
