using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MVC.Models.SharedFields;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("ModeloHelice")]
    public class ModeloHelice : TimesReplacement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int MarcaID { get; set; }
        public string Nombre { get; set; }

        [ForeignKey(nameof(MarcaID))]
        public virtual MarcaHelice? MarcaHelice { get; set; }
        public virtual ICollection<Helice>? Helices { get; set; }
    }
}
