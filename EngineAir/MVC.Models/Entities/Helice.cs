using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MVC.Models.SharedFields;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Helice")]
    public class Helice : CtrlReplacement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ModeloID { get; set; }

        [ForeignKey(nameof(ModeloID))]
        public virtual ModeloHelice ModeloHelice { get; set; }

        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
    }
}
