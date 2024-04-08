using MVC.Models.Entities.GeneralFields;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("ModeloHelice")]
    public class ModeloHelice : ModelFields
    {
        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaTipoID))]
        public virtual MarcaHelice Marca { get; set; }

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Helice>? Helices { get; set; }
    }
}
