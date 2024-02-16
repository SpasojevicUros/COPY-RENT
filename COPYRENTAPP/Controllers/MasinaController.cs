using Microsoft.AspNetCore.Mvc;
using ProjekatPPP.Models.BO;
using ProjekatPPP.Services;
using ProjekatPPP.Views.ViewModels;

namespace ProjekatPPP.Controllers
{
    public class MasinaController : Controller
    {
        private readonly IMasinaServices _masinaService;
        private readonly IKupacService _kupacService;
        public MasinaController(IMasinaServices masinaServices, IKupacService kupacService)
        {
            _masinaService = masinaServices;
            _kupacService = kupacService;
        }

        public IActionResult GetAllMasine()
        {
            var listaMasina = _masinaService.GetAll();
           
            var getAllMasineVM = new List<GetAllMasineViewModel>();
            foreach(var masina in listaMasina)
            {
                var nazivFirme = _kupacService.GetById(masina.izdataKupcu)?.imeFirme;

                getAllMasineVM.Add(new GetAllMasineViewModel()
                {
                    idMasine = masina.idMasine,
                    proizvodjac = masina.proizvodjac,
                    model = masina.model,
                    cena = masina.cena,
                    opis = masina.opis,
                    brojKopija = masina.brojKopija,
                    izdataKupcu = nazivFirme
                });
            }
            return View(getAllMasineVM);
        }

        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                MasinaBO masina = new MasinaBO();
                masina.proizvodjac = collection["proizvodjac"];
                masina.model = Convert.ToInt32(collection["model"]);
                masina.brojKopija = Convert.ToInt32(collection["brojKopija"]);
                masina.cena = (float)Convert.ToDouble(collection["cena"]);
                masina.opis = collection["opis"];
                masina.izdataKupcu = Convert.ToInt32(collection["izdataKupcu"]);
                _masinaService.Create(masina);
                return RedirectToAction(nameof(GetAllMasine));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var masina = _masinaService.GetById(id);
            return View(masina);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var masina = _masinaService.GetById(id);
                masina.proizvodjac = collection["proizvodjac"];
                masina.model = Convert.ToInt32(collection["model"]);
                masina.brojKopija = Convert.ToInt32(collection["brojKopija"]);
                masina.cena = (float)Convert.ToDouble(collection["cena"]);
                masina.opis = collection["opis"];
                masina.izdataKupcu = Convert.ToInt32(collection["izdataKupcu"]);
                _masinaService.Update(masina);
                return RedirectToAction(nameof(GetAllMasine));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var masina = _masinaService.GetById(id);
            return View(masina);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var masina = _masinaService.GetById(id);
                _masinaService.Delete(masina);
                return RedirectToAction(nameof(GetAllMasine));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult IzdajMasinu(int idKupca, int idMasine)
        {
            var masina = _masinaService.IzdajMasinu(idKupca, idMasine);
            var kupci = _kupacService.GetAll();
            var iznajmljivanjeMasineVM = new IznajmljivanjeMasineViewModel()
            {
                idMasine = idMasine,
                listaKupaca = kupci,
            };
            return View(iznajmljivanjeMasineVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IzdajMasinu(IFormCollection collection)
        {
            try
            {
                var nazivFirme = collection["listaKupaca"][0];
                var idKupca = _kupacService.GetByCompanyName(nazivFirme).idKupca;

                var idMasine = Convert.ToInt32(collection["idMasine"]);

                var masina = _masinaService.IzdajMasinu(idKupca, idMasine);
                
                return RedirectToAction(nameof(GetAllMasine));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult VratiMasinu(int idMasine)
        {
            var masinaZaVracaenje = _masinaService.GetById(idMasine);
            return View(masinaZaVracaenje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VratiMasinu(IFormCollection collection)
        {
            try
            {
                var idMasine = collection["idMasine"];
                var masina = _masinaService.GetById(Convert.ToInt32(idMasine));
                _masinaService.VratiMasinu(masina);
                return RedirectToAction(nameof(GetAllMasine));
            }
            catch
            {
                return View();
            }
        }
    }
}
