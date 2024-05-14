using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models.Classes;
using MVC.Models.Entities;
using MVC.Models.Entities.GeneralFields;
using System.Text.Json.Serialization;

namespace MVC.Models.ViewModels
{
    // Generalidades de los ViewModels - - - - - - - - - - - - -
    public class ComponentViewModel<marcaTipo, modeloVariante>
    where marcaTipo : BrandFields
    where modeloVariante : ModelFields
    {
        public List<marcaTipo> MarcasTipos { get; set; } = new();
        public List<modeloVariante> ModelosVariantes { get; set; } = new();

        public MarcaTipoViewModel MarcaTipo { get; set; } = new();
        public ModeloVarianteViewModel ModeloVariante { get; set; } = new();
         
        public MotorViewModel? MotorViewModel { get; set; } = new();

        //public HeliceViewModel? HeliceViewModel { get; set; } = new();

        //public HeliceViewModel? HeliceViewModel { get; set; } = new();
        //public OtroComponenteViewModel? OtroComponenteViewModel { get; set; } = new();
    } 

    public class UpdateStatusDTO
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Entidad")]
        public string Entidad { get; set; } = string.Empty;

        [JsonPropertyName("Status")]
        public bool? Status { get; set; }
    }

    public class MarcaTipoViewModel
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public string Entidad { get; set; } = string.Empty;
        public string? ClientID { get; set; } = string.Empty;
    }

    public class ModeloVarianteViewModel
    {
        public string Entidad { get; set; } = string.Empty;
        public int MarcaTipoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? TiempoRemplazoHrs { get; set; }
        public bool UnidadTiempo { get; set; }
        public int? Cantidad { get; set; }

        public bool Estado { get; set; } = true;
        public string? ClientID { get; set; } = string.Empty;

        public int? MesesTotales()
        {
            if (UnidadTiempo == false)
                return Cantidad * 12;
            else
                return Cantidad;
        }
    }

    // Generalidades de los componentes - - - - - - - - - - - - -
    public class ComponenteViewModel
    {
        public int ModeloVarianteID { get; set; }
        public bool Estado { get; set; } = true;
        public string NumSerie { get; set; } = string.Empty;
        public string Entidad { get; set; } = string.Empty;

        public Decimal TiempoTotal { get; set; }
        public Decimal TURM { get; set; }
    }

    public class MotorViewModel : ComponenteViewModel
    {
        public int? Aeronave { get; set; }
        public int? HeliceID { get; set; }
    }

    //public class HeliceViewModel : ComponenteViewModel
    //{

    //}

    public class OtroComponenteViewModel : ComponenteViewModel
    {
        public int? Aeronave { get; set; }
    }
}
