using Microsoft.AspNetCore.Mvc;

namespace EngineAir.Controllers
{
    public class ComponentesController : Controller
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
