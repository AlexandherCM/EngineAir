using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("MarcaMotor")] 
    public class MarcaMotor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; }
        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<ModeloMotor>? Modelos { get; set;} = new List<ModeloMotor>();
    } 
}
