using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("Variante")]
    public class Variante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MarcaID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Decimal TiempoRemplazoHrs { get; set; }
        public int TiempoRemplazoMeses { get; set; }

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaID))]
        public virtual TipoComponente Tipo { get; set; } = new TipoComponente();

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Componente> Componentes { get; set;} = new List<Componente>();
    }
}
