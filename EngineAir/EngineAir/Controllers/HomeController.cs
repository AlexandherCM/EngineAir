using EngineAir.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EngineAir.Controllers
{
    public class HomeController : Controller
    {
        //private readonly Context _context;

        //public HomeController(Context context)
        //{
        //    //_context = context;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Motores()
        {
            return RedirectToAction("Motor", "Componentes");
        }
        public IActionResult Helices()
        {
            return RedirectToAction("Helice", "Componentes");
        }

        public IActionResult Componentes()
        {
            return RedirectToAction("Variante", "Componentes");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}