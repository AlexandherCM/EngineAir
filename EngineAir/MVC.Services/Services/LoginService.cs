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

        public CorreoDTO CrearPlantilla( HttpContext HttpContext, Usuario usuario, string Destinatario, string plantilla, string ruta)
        {
            string folder = "Plantillas";

            // Utiliza el hostingEnvironment para resolver la ruta física
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string webRootPath = Path.Combine(currentDirectory, "..", "wwwroot");

            string path = Path.Combine(webRootPath, folder, plantilla);

            string scheme = HttpContext.Request.Scheme;
            string host = HttpContext.Request.Host.ToString();
            string url = $"{scheme}://{host}/{ruta}";


            StreamReader reader = new StreamReader(path);
            string htmlBody = string.Format(reader.ReadToEnd(), url, usuario.Nombre);


            CorreoDTO correoDTO = new CorreoDTO()
            {
                Para = Destinatario,
                Asunto = "Confirmación de cuenta",
                Contenido = htmlBody
            };

            return correoDTO;
        }
    }
}
