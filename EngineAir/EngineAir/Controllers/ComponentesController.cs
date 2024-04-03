using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Classes;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Services;
using System.Data;

namespace EngineAir.Controllers
{
    public class ComponentesController : Controller
    {
        private readonly ComponentService _service;
        private ResponseJS _alertaEstado = new();

        private ComponentViewModel<MarcaMotor> ViewModel = new();

        //private ComponentViewModel _viewModel = new(); 
        public ComponentesController(ComponentService service)
        {
            _service = service;
        }

        // End-Points de la interfaz de los motores - - - - - - - - - - - -

        [Authorize(Roles = "ADM, GRL")]
        public async Task<IActionResult> Motor()
        {
            this.ViewModel = new()
            {
                MarcasTipos = await _service.GetMarcasMotores()
            };

            return View(ViewModel);
        }
        // End-Points de la interfaz de las hélices- - - - - - - - - - - - -

        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Helice()
        {
            return View();
        }

        // End-Points de la interfaz de otros componentes - - - - - - - - - -

        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Variante()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADM, GRL")]
        public async Task<IActionResult> CreateBrand(MarcaTipo MarcaTipo) 
        {
            _alertaEstado = await _service.CreateBrand(MarcaTipo);
            ViewBag.Alerta = _alertaEstado;

            return MarcaTipo.Entidad switch
            {
                "MarcaMotor" => 
                    View(nameof(Motor)),
                "MarcaHelice" => 
                    View(nameof(Helice)),
                "Tipo" => 
                    View(nameof(Variante)),
                _ => 
                    RedirectToAction("Index", "Home"),
            };
        }   
    }
}
