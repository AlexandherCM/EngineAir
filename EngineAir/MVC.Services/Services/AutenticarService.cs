using EngineAir.Models;
using Microsoft.AspNetCore.Http;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace MVC.Services.Services
{
    public class AutenticarService
    {
        private readonly Context _context;
        
        LoginService LoginService = new LoginService();

        public AutenticarService(Context context )
        {
            _context = context;
        }

        public async Task<string> IniciarSesion(SesionViewModel sesion, HttpContext HttpContext)
        {
            var Mensaje = "Las credenciales son incorrectas.";

            List<Usuario> Usuarios = await _context.Usuario
            .Where(c => c.Correo == sesion.Correo && c.Clave == LoginService.EncriptarPassword(sesion.Clave))
            .Include(r => r.Perfil)
            .ToListAsync();

            var usuario = Usuarios.FirstOrDefault();
            if (usuario != null)
            {
                if (usuario.Validado != false)
                {
                    if (usuario.Restablecer != true)
                    {
                        await CrearCoockie(usuario, HttpContext);
                        return Mensaje = "ok";
                    }
                    return Mensaje = "Ha solicitado la recuperacion de la cuenta, favor de revisar su correo.";
                }
                return Mensaje = "La cuenta esta en espera de validacion.";
            }

            return Mensaje;
        }

        public async Task<string> RegistrarUsuario(string plantilla, SesionViewModel sesion, HttpContext httpContext)
        {
            string Mensaje = "Las contraseñas no coinciden";

            if(sesion.Clave == sesion.ConfirmarClave)
            {
                var Usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == sesion.Correo);
                if (Usuario == null)
                {
                    var NuevoUsuario = LoginService.CrearUsuario(sesion, "GRL", false);
                    var Ruta = $"Home/Confirmar?token={NuevoUsuario.Token}";
                    string asunto = "Confirmacion de cuenta";
                     
                    var Correo = LoginService.CrearPlantilla(httpContext, NuevoUsuario, plantilla, asunto, Ruta);
                    bool Enviado = LoginService.EnviarCorreo(Correo);

                    if (Enviado)
                    {
                        _context.Usuario.Add(NuevoUsuario);
                        await _context.SaveChangesAsync();
                        return Mensaje = "Su cuenta esta en espera de aceptacion, favor de esperar el correo de validacion.";
                    }
                    return Mensaje = "¡No se pudo completar el registro, intentelo de nuevo!";
                }
                return Mensaje = "Ya existe un usuario asociado a esa cuenta";
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
