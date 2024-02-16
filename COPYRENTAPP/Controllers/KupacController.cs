using Microsoft.AspNetCore.Mvc;
using ProjekatPPP.Models.BO;
using ProjekatPPP.Services;

namespace ProjekatPPP.Controllers
{
    public class KupacController : Controller
    {
        private readonly IKupacService _kupacService;

        public KupacController(IKupacService kupacService)
        {
            _kupacService = kupacService;
        }

        public IActionResult GetAllKupce()
        {
            var listaKupaca = _kupacService.GetAll();
            return View(listaKupaca);
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
                KupacBO kupac = new KupacBO();
                //kupac.idKupca = Convert.ToInt32(collection["idKupca"]);
                kupac.imeFirme = collection["imeFirme"];
                kupac.bankovniRacun = Convert.ToInt32(collection["bankovniRacun"]);
                kupac.pib = Convert.ToInt32(collection["pib"]);
                _kupacService.Create(kupac);
                return RedirectToAction(nameof(GetAllKupce));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var kupac = _kupacService.GetById(id);
            return View(kupac);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var kupac = _kupacService.GetById(id);
                kupac.imeFirme = collection["imeFirme"];
                kupac.bankovniRacun = Convert.ToInt32(collection["bankovniRacun"]);
                kupac.pib = Convert.ToInt32(collection["pib"]);
                _kupacService.Update(kupac);
                return RedirectToAction(nameof(GetAllKupce));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var kupac = _kupacService.GetById(id);
            return View(kupac);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var kupac = _kupacService.GetById(id);
                _kupacService.Delete(kupac);
                return RedirectToAction(nameof(GetAllKupce));
            }
            catch
            {
                return View();
            }
        }
    }
}
