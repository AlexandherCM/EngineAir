using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("MarcaHelice")]
    public class MarcaHelice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<ModeloHelice> Modelos { get; set; } = new List<ModeloHelice>(); 
    }
}
