using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("MarcaMotor")]
    public class MarcaMotor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ModeloMotor> ModelosMotor { get; set; }
    }
}
