using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("MarcaHelice")]
    public class MarcaHelice : BrandFields
    {
        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<ModeloHelice>? Modelos { get; set; } = new List<ModeloHelice>(); 
    }
}
