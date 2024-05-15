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

        //private ComponentViewModel _viewModel = new(); 
        public ComponentesController(ComponentService service)
        {
            _service = service;
        }

        // End-Points de la interfaz de los motores - - - - - - - - - - - -

        [Authorize(Roles = "ADM, GRL")]
        public async Task<IActionResult> Motor()
        {
            ComponentViewModel<MarcaMotor, ModeloMotor> MotorViewModel = new()
            {
                MarcasTipos = await _service.GetMarcasMotores(),
                ModelosVariantes = await _service.GetModelosMotores(),
                Helices = await _service.GetHelicesDisponibles(),
            };
            return View(MotorViewModel);
        }

        // End-Points de la interfaz de las hélices- - - - - - - - - - - - -

        [Authorize(Roles = "ADM, GRL")]
        public async Task<IActionResult> Helice()
        {
            ComponentViewModel<MarcaHelice, ModeloHelice> HeliceViewModel = new()
            {
                MarcasTipos = await _service.GetMarcasHelices(),
                ModelosVariantes = await _service.GetModelosHelices()
            };

            return View(HeliceViewModel);
        }

        // End-Points de la interfaz de otros componentes - - - - - - - - - -

        [Authorize(Roles = "ADM, GRL")]
        public async Task<IActionResult> Variante()
        { 
            ComponentViewModel<TipoComponente, Variante> TipoComponenteViewModel = new()
            {
                MarcasTipos = await _service.GetTiposComponente(),
                ModelosVariantes = await _service.GetVariantesComponente()
            }; 

            return View(TipoComponenteViewModel);
        }

    }
}
