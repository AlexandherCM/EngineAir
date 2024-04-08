using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("ModeloMotor")]
    public class ModeloMotor : ModalFields
    {
        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaTipoID))] 
        public virtual MarcaMotor? Marca { get; set; }

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Motor>? Motores { get; set; }
    }
}
