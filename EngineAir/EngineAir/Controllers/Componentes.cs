using Microsoft.AspNetCore.Mvc;

namespace EngineAir.Controllers
{
    public class Componentes : Controller
    {
        public IActionResult Motor()
        {
            return View();
        }

        public IActionResult Helice()
        {
            return View();
        }

        public IActionResult Variante()
        {
            return View();
        }
    }
}
