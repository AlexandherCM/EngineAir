﻿using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.Services;

namespace EngineAir.Controllers
{
    public class ComponentesController : Controller
    {
        private ComponentService _service;
        private AlertaEstado _alertaEstado = new();

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
        public async Task<IActionResult> CreateBrand(MarcaTipoDTO MarcaTipo) 
        {
            _alertaEstado = await _service.CreateBrand(MarcaTipo);
            ViewBag.Alerta = _alertaEstado;

            switch (MarcaTipo.Entidad)
            {
                case "MarcaMotor":
                    return RedirectToAction(nameof(Motor));
                case "MarcaHelice":
                    return RedirectToAction(nameof(Helice));
                case "Tipo":
                    return RedirectToAction(nameof(Variante));
                default: 
                    return RedirectToAction(nameof(Motor));
            }
        }
    }
}