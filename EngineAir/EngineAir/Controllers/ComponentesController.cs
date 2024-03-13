﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.Services;

namespace EngineAir.Controllers
{
    public class ComponentesController : Controller
    {
        private readonly ComponentService _service;
        private AlertaEstado _alertaEstado = new();

        //private ComponentViewModel _viewModel = new(); 
        public ComponentesController(ComponentService service)
        {
            _service = service;
        }

        // End-Points de la interfaz de los motores - - - - - - - - - - - -
        public async Task<IActionResult> Motor()
        {
            MotorViewModel model = new()
            {
                MarcasTipos = await _service.GetMarcasMotores()
            };

            return View(model);
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
