using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("HistorialMotorHelice")]
    public class HistorialMotorHelice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }     
        public int MotorID { get; set; }     
        public int HeliceID { get; set; }      
        public bool Estado { get; set; }

        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MotorID))]
        public virtual Motor Motor { get; set; } = new Motor();

        [ForeignKey(nameof(HeliceID))]
        public virtual Helice Helice { get; set; } = new Helice();
    }
}
