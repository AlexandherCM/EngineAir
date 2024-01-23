using MVC.Models.SharedFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace MVC.Models.ViewModels
{
    public class ModelViewModel
    {
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [Display(Name= "Marca")]
        [Required(ErrorMessage = "El campo marca es obligatorio")]
        public int BrandID { get; set; }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Name { get; set; }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [Display(Name = "Tiempo de remplazo en horas")]
        [Required(ErrorMessage = "El campo horas es obligatorio")]
        public int ReplaceHrs { get; set; }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [Display(Name = "Tiempo de remplazo en años")]
        [Required(ErrorMessage = "El campo años es obligatorio")]
        public int Years { get; set; }
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

        // Other fields - - - - - - - - - - - - - - - - - - - - - 
        public string Entity { get; set; }
        // Conversions - - - - - - - - - - - - - - - - - - - - - - 
        public int Months { get; set; }
    }
}
