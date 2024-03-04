using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("MarcaHelice")]
    public class MarcaHelice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; }
        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<ModeloHelice>? Modelos { get; set; } = new List<ModeloHelice>(); 
    }
}
