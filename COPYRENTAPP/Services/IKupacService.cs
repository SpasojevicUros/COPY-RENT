using ProjekatPPP.Models.BO;

namespace ProjekatPPP.Services
{
    public interface IKupacService
    {
        List<KupacBO> GetAll();
        KupacBO GetById(int id);
        KupacBO GetByCompanyName(string nazivFirme);
        KupacBO Create(KupacBO noviKupac);
        KupacBO Update(KupacBO izmenjenKupac);
        void Delete(KupacBO kupacZaBrisanje);
    }
}
