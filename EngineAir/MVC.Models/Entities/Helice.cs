using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("Helice")]
    public class Helice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ModeloID { get; set; }
        public bool Funcional { get; set; }
        public string NumSerie { get; set; } = string.Empty;
        public Decimal TiempoTotal { get; set; }
        public Decimal TURM { get; set; }

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(ModeloID))]
        public virtual ModeloHelice? Modelo { get; set; } = new ModeloHelice(); 
    }
}
