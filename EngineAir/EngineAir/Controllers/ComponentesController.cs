using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using MVC.Services.Services;

namespace EngineAir.Controllers
{
    public class ComponentesController : Controller
    {
        private ComponentService _service;
        //private ComponentViewModel _viewModel = new(); 
        public ComponentesController(ComponentService service)
        {
            _service = service;
        }

        // End-Points de la interfaz de los motores - - - - - - - - - - - -
        public IActionResult Motor()
        {
            return View();
        }
        // End-Points de la interfaz de las hélices- - - - - - - - - - - - -
        public IActionResult Helice()
        {
            return View();
        }

        // End-Points de la interfaz de otros componentes - - - - - - - - - -
        public IActionResult Variante()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MarcaTipoDTO MarcaTipo) 
        {
            return RedirectToAction(nameof(Motor)); // Varia
        }
    }
}
