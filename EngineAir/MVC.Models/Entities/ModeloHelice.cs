using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("ModeloHelice")]
    public class ModeloHelice
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
        public virtual MarcaHelice? Marca { get; set; } = new MarcaHelice(); 

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Helice>? Helices { get; set; } = new List<Helice>();
    }
}
