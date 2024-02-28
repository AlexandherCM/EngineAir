using EngineAir.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}