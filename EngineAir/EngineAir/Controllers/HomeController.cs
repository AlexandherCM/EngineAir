using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using MVC.Services.Services;
using System.Diagnostics;

namespace EngineAir.Controllers
{
    public class HomeController : Controller
    {
        private readonly AutenticarService _service;

        public HomeController(AutenticarService service)
        {
            _service = service;
        }

        //[Authorize(Roles = "ADM")]
        public IActionResult Index()
        {
            string rol =
                    User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;

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

        // Operaciones del servicio de autenticación de usuario - - - - - - - - - - - - - - - - - - - - - - - - 
        [Authorize(Roles = "ADM, GRL")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.Sesion = TempData["Sesion"];
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

        [Authorize(Roles = "ADM, GRL")]
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