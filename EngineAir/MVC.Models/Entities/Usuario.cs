using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string PerfilID { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public bool Restablecer { get; set; }
        public bool Validado { get; set; }
        public string Token { get; set; } = string.Empty;

        [ForeignKey(nameof(PerfilID))]
        public virtual Perfil Perfil { get; set; } = new Perfil();
    }
}
