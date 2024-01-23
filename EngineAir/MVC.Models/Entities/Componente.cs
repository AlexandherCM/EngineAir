using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MVC.Models.SharedFields;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Componente")]
    public class Componente : CtrlGralReplacement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? AeronaveID { get; set; }
        public int CatalogoID { get; set; }

        [ForeignKey(nameof(AeronaveID))]
        public virtual Aeronave Aeronave { get; set; }

        [ForeignKey(nameof(CatalogoID))]
        public virtual Catalogo Catalogo { get; set; }

        public virtual ICollection<Seguimiento> Seguimiento { get; set; }
    }
}
