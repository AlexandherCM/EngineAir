using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("Variante")]
    public class Variante : ModalFields
    {
        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaTipoID))]
        public virtual TipoComponente? Tipo { get; set; }

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Componente>? Componentes { get; set;}
    }
}
