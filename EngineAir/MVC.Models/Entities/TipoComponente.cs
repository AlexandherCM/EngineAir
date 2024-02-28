﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("TipoComponente")]
    public class TipoComponente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; }
        public string Nombre { get; set; } = string.Empty;

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Variante> Variantes { get; set; } = new List<Variante>();
    }
}
