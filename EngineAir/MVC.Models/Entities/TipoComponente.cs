using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("TipoComponente")]
    public class TipoComponente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Componente { get; set; }
        public virtual ICollection<Catalogo> Catalogo { get; set;}
    }
}
