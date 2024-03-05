using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("MarcaMotor")] 
    public class MarcaMotor : BrandFields
    {
        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<ModeloMotor>? Modelos { get; set;} = new List<ModeloMotor>();
    } 
}
