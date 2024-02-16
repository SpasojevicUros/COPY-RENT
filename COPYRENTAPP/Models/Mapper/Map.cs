using ProjekatPPP.Models.BO;
using ProjekatPPP.Models.Entity;

namespace ProjekatPPP.Models.Maper
{
    public static class Map
    {
        public static MasinaBO ConvertToBO(this Masina masina) 
        {
            return new MasinaBO()
            {
                idMasine = masina.idMasine,
                proizvodjac = masina.proizvodjac,
                model = masina.model,
                brojKopija = masina.brojKopija,
                cena = masina.cena,
                opis = masina.opis,
                izdataKupcu = masina.izdataKupcu
            };
        }
        public static Masina ConvertToEntity(this MasinaBO masina)
        {
            return new Masina()
            {
                idMasine = masina.idMasine,
                proizvodjac = masina.proizvodjac,
                model = masina.model,
                brojKopija = masina.brojKopija,
                cena = masina.cena,
                opis = masina.opis,
                izdataKupcu = masina.izdataKupcu
            };
        }

        public static KupacBO ConvertToBO(this Kupac kupac) 
        {
            return new KupacBO()
            {
                idKupca = kupac.idKupca,
                imeFirme = kupac.imeFirme,
                bankovniRacun = kupac.bankovniRacun,
                pib = kupac.pib
            };
        }

        public static Kupac ConvertToEntity(this KupacBO kupac)
        {
            return new Kupac()
            {
                idKupca = kupac.idKupca,
                imeFirme = kupac.imeFirme,
                bankovniRacun = kupac.bankovniRacun,
                pib = kupac.pib
            };
        }

        public static FakturaBO ConvertToBO(this Faktura faktura)
        {
            return new FakturaBO()
            {
                idFakture = faktura.idFakture,
                pib = faktura.pib,
                cena = faktura.cena,
                idKupca = faktura.idKupca,
                idMasine = faktura.idMasine
            };
        }

        public static Faktura ConvertToEntity(this FakturaBO faktura)
        {
            return new Faktura()
            {
                idFakture = faktura.idFakture,
                pib = faktura.pib,
                cena = faktura.cena,
                idKupca = faktura.idKupca,
                idMasine = faktura.idMasine
            };
        }
    }
}
