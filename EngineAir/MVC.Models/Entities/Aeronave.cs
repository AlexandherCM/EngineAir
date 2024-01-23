using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Aeronave")]
    public class Aeronave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ModeloID { get; set; }
        public bool MonoMotor { get; set; }
        public string Matricula { get; set; }
        public string Propietario { get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey(nameof(ModeloID))]
        public virtual ModeloAeronave ModeloAvion { get; set; }

        public virtual ICollection<Motor> Motores { get; set; }
        public virtual ICollection<Componente> Componentes { get; set; }
    }
}
