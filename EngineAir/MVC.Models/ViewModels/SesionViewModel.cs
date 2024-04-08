using System.ComponentModel.DataAnnotations;

namespace MVC.Models.ViewModels
{
    public class SesionViewModel
    {
        [Required(ErrorMessage = "El campo correo es obligatorio")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo contaseña es obligatorio")]
        public string Clave { get; set; } = string.Empty;
    }
}
