using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

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
        public decimal TiempoTotal { get; set; }
        public decimal TURM { get; set; }

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(ModeloID))]
        public virtual ModeloHelice Modelo { get; set; }
    }
}
