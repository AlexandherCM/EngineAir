using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("Componente")]
    public class Componente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int VarianteID { get; set; } 
        public int? Aeronave { get; set; }
        public bool Funcional { get; set; }
        public string NumSerie { get; set; } = string.Empty;

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(VarianteID))]
        public virtual Variante? Variante { get; set; }
    }
}
