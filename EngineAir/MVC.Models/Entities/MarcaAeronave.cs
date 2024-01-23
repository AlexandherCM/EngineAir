using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("MarcaAeronave")]
    public class MarcaAeronave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ModeloAeronave> ModelosAeronave { get; set; }
    }
}
