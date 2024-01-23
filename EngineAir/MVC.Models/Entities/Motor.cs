using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MVC.Models.SharedFields;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Motor")]
    public class Motor : CtrlReplacement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? AvionID { get; set; }
        public int? HeliceID { get; set; }
        public int ModeloID { get; set; }

        [ForeignKey(nameof(ModeloID))]
        public virtual ModeloMotor ModeloMotor { get; set; }

        [ForeignKey(nameof(AvionID))]
        public virtual Aeronave Aeronave { get; set; }

        [ForeignKey(nameof(HeliceID))]
        public virtual Helice Helice { get; set; }

        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
    }
}
