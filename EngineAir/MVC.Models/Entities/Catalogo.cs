using MVC.Models.SharedFields;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("Catalogo")]
    public class Catalogo : TimesReplacement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int TipoID { get; set; }
        public string Modelo { get; set; }

        [ForeignKey(nameof(TipoID))]
        public virtual TipoComponente TipoComponente { get; set; }
        public virtual ICollection<Componente> Componentes { get; set; }
    }
}
