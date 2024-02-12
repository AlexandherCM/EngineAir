using Microsoft.AspNetCore.Mvc;

namespace EngineAir.Controllers
{
    public class Componente : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Motor()
        {
            return View();
        }
        public IActionResult Helice()
        {
            return View();
        }
    }
}
