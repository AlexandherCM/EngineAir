using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Variante")]
    public class Variante : ModelFields
    {
        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaTipoID))]
        public virtual TipoComponente Tipo { get; set; }

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Componente>? Componentes { get; set;}
    }
}
