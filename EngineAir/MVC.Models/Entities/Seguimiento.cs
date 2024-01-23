using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models.Entities
{
    [Table("Seguimiento")]
    public class Seguimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? MotorID { get; set; }
        public int? HeliceID { get; set; }
        public int? ComponenteID { get; set; }

        public decimal UltimaAplicacionHrs { get; set; }
        public DateTime UltimaAplicacionFecha { get; set; }
        public decimal ProximaAplicacionHrs { get; set; }
        public DateTime ProximaAplicacionFecha { get; set; }
        public decimal RemanenteHrs { get; set; }
        public int RemanenteMeses { get; set; }
    }
}
