using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Componente")]
    public class Componente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int VarianteID { get; set; } 
        public int? AeronaveID { get; set; } 
        public bool Funcional { get; set; }
        public string NumSerie { get; set; } = string.Empty;
        public decimal TiempoTotal { get; set; }
        public decimal TURM { get; set; }

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(VarianteID))]
        public virtual Variante Variante { get; set; }
    }
}
