using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("ModeloAeronave")]
    public class ModeloAeronave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MarcaID { get; set; }
        public string Nombre { get; set; }

        [ForeignKey(nameof(MarcaID))]
        public virtual MarcaAeronave MarcaAeronave { get; set; }
        public virtual ICollection<Aeronave> Aeronaves { get; set; }
    }
}
