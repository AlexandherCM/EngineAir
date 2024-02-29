using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using System.Diagnostics;

namespace EngineAir.Controllers
{
    public class HomeController : Controller
    {
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