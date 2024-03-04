using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("ModeloMotor")]
    public class ModeloMotor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MarcaID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Decimal? TiempoRemplazoHrs { get; set; }
        public int? TiempoRemplazoMeses { get; set; }
        public bool Estado { get; set; }

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaID))] 
        public virtual MarcaMotor? Marca { get; set; } = new MarcaMotor();

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Motor>? Motores { get; set; } = new List<Motor>(); 
    }
}
