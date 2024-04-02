using EngineAir.Models;
using Microsoft.AspNetCore.Http;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace MVC.Services.Services
{
    public class AutenticarService
    {
        private readonly Context _context;

        public AutenticarService(Context context)
        {
            _context = context;
        }

        public async Task<string> IniciarSesion(SesionViewModel sesion, HttpContext HttpContext)
        {
            var Mensaje = "Las credenciales son incorrectas.";

            //var Clave = _herramientaRegistro.EncriptarPassword(sesion.Clave);
            List<Usuario> Usuarios = await _context.Usuario
            .Where(c => c.Correo == sesion.Correo && c.Clave == sesion.Clave)
            .Include(r => r.Perfil)
            .ToListAsync();

            var usuario = Usuarios.FirstOrDefault();
            if (usuario != null)
            {
                await CrearCoockie(usuario, HttpContext);
                return Mensaje = "ok";
            }

            return Mensaje;
        }

        public async Task CerrarSesion(HttpContext HttpContext)
            => await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        private static async Task CrearCoockie(Usuario usuario, HttpContext httpContext)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.ID.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.Role, usuario.Perfil.ID)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
