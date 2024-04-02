using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Entities
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        [MaxLength(3)]
        public string ID { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
}
