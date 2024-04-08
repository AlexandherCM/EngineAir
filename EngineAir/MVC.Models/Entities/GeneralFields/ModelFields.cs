using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Entities.GeneralFields
{
    public class ModelFields 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public int MarcaTipoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal? TiempoRemplazoHrs { get; set; }
        public int? TiempoRemplazoMeses { get; set; }
        public bool Estado { get; set; }
    }
}
