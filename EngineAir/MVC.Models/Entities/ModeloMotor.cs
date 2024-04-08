using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("ModeloMotor")]
    public class ModeloMotor : ModelFields
    {
        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaTipoID))] 
        public virtual MarcaMotor Marca { get; set; }

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Motor>? Motores { get; set; }
    }
}
