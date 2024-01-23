using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace MVC.Models.ViewModels
{
    public class BrandViewModel
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Entidad { get; set; }
    }
}
