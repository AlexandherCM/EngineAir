using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MVC.Models.DTO;


namespace MVC.Services.Services
{
    internal class LoginService
    {
        public string EncriptarPassword(string password)
        {
            string hash = string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] valor = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (byte b in valor)
                {
                    hash += $"{b:x2}";
                }
            }
            return hash;
        }

        public Usuario CrearUsuario(SesionViewModel user, string perfil, bool validado)
        {
            var usuarioNuevo = new Usuario()
            {
                PerfilID = perfil,
                Nombre = user.Nombre,
                Correo = user.Correo,
                Clave = EncriptarPassword(user.Clave),
                Restablecer = false,
                Validado = validado,
                Token = GenerarToken(),
            };
            return usuarioNuevo;
        }

        private string GenerarToken()
        {
            string token = Guid.NewGuid().ToString("N");
            return token;
        }

        public CorreoDTO CrearPlantilla( HttpContext HttpContext, Usuario usuario, string plantilla, string asunto,  string ruta)
        {
            string scheme = HttpContext.Request.Scheme;
            string host = HttpContext.Request.Host.ToString();
            string url = $"{scheme}://{host}/{ruta}";

            StreamReader reader = new StreamReader(plantilla);
            string htmlBody = string.Format(reader.ReadToEnd(), usuario.Nombre, url);

            CorreoDTO correoDTO = new CorreoDTO()
            {
                Para = "carlosivan12.ci2@gmail.com",
                Asunto = asunto,
                Contenido = htmlBody
            };

            return correoDTO;
        }
    }
}
