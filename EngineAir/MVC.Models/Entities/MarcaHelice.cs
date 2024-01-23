﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace MVC.Models.Entities
{
    [Table("MarcaHelice")]
    public class MarcaHelice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ModeloHelice> ModelosHelice { get; }
    }
}
