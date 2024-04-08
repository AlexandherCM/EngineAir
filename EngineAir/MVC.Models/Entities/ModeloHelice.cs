using MVC.Models.Entities.GeneralFields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Models.Entities
{
    [Table("ModeloHelice")]
    public class ModeloHelice : ModalFields
    {
        // Relaciones - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        [ForeignKey(nameof(MarcaTipoID))]
        public virtual MarcaHelice? Marca { get; set; }

        // Conjuntos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        public virtual List<Helice>? Helices { get; set; }
    }
}
