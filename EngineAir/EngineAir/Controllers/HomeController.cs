using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using MVC.Services.Services;
using System.Diagnostics;

namespace EngineAir.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AutenticarService _service;

        public HomeController(AutenticarService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Motores()
        {
            return RedirectToAction("Motor", "Componentes");
        }

        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Helices()
        {
            return RedirectToAction("Helice", "Componentes");
        }

        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Componentes()
        {
            return RedirectToAction("Variante", "Componentes");
        }

        // Operaciones del servicio de autenticación de usuario - - - - - - - - - - - - - - - - - - - - - - - - 
        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.Sesion = TempData["Sesion"];
            ViewBag.Registro = TempData["Registro"];
            return View();
        }

        public async Task<IActionResult> ValidarAcceso(SesionViewModel sesion)
        {
            var Acceso = await _service.IniciarSesion(sesion, HttpContext);
            if (Acceso == "ok")
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["Sesion"] = Acceso;
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> CrearCuenta(SesionViewModel sesion)
        {
            string Plantilla = Path.Combine(_webHostEnvironment.WebRootPath, "Plantillas", "confirmar.html");

            var Registro = await _service.RegistrarUsuario(Plantilla, sesion, HttpContext);

            TempData["Registro"] = Registro;
           return RedirectToAction(nameof(Login));
        }

        //[Authorize(Roles = "ADM, GRL")]
        public async Task<IActionResult> Logout()
        {
            await _service.CerrarSesion(HttpContext);
            return RedirectToAction(nameof(Login));
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}