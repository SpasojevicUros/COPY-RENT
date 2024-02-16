using Microsoft.AspNetCore.Mvc;
using ProjekatPPP.Models.BO;
using ProjekatPPP.Services;

namespace ProjekatPPP.Controllers
{
    public class FakturaController : Controller
    {
        private readonly IFakturaService _fakturaService;

        public FakturaController(IFakturaService fakturaService)
        {
            _fakturaService = fakturaService;
        }

        public IActionResult GetAllFakture()
        {
            var listaFaktura = _fakturaService.GetAll();
            return View(listaFaktura);
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
                FakturaBO faktura = new FakturaBO();
                faktura.pib = Convert.ToInt32(collection["pib"]);
                faktura.cena = (float)Convert.ToDouble(collection["cena"]);
                faktura.idMasine = Convert.ToInt32(collection["idMasine"]);
                faktura.idKupca = Convert.ToInt32(collection["idKupca"]);
                _fakturaService.Create(faktura);
                return RedirectToAction(nameof(GetAllFakture));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            var faktura = _fakturaService.GetById(id);
            return View(faktura);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var faktura = _fakturaService.GetById(id);
                faktura.pib = Convert.ToInt32(collection["pib"]);
                faktura.cena = (float)Convert.ToDouble(collection["cena"]);
                faktura.idMasine = Convert.ToInt32(collection["idMasine"]);
                faktura.idKupca = Convert.ToInt32(collection["idKupca"]);
                _fakturaService.Update(faktura);
                return RedirectToAction(nameof(GetAllFakture));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var faktura = _fakturaService.GetById(id);
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var faktura = _fakturaService.GetById(id);
                _fakturaService.Delete(faktura);
                return RedirectToAction(nameof(GetAllFakture));
            }
            catch
            {
                return View();
            }
        }
    }
}
