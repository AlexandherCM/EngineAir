using MVC.Models.Classes;
using MVC.Models.Entities;
using MVC.Models.Entities.GeneralFields;
using System.Text.Json.Serialization;

namespace MVC.Models.ViewModels
{
    // Generalidades de los ViewModels - - - - - - - - - - - - -
    public class ComponentViewModel<T> where T : BrandFields
    {
        public List<T> MarcasTipos { get; set; } = new();
        public MarcaTipo MarcaTipo { get; set; } = new();
        public ModeloVariante ModeloVariante { get; set; } = new();
    }   

    public class MarcaTipo
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public string Entidad { get; set; } = string.Empty;
        public string? ClientID { get; set; } = string.Empty;
    } 

    public class ModeloVariante
    {
        public int MarcaTipoID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Decimal? TiempoRemplazoHrs { get; set; }
        public int? TiempoRemplazoMeses { get; set; }
        public bool Estado { get; set; } = true;
        public string Entidad { get; set; } = string.Empty;
    }

    // Generalidades de los componentes - - - - - - - - - - - - -
    public abstract class Componente
    {
        protected int ModeloVarianteID { get; set; }
        protected bool Estado { get; set; } = true;
        protected string NumSerie { get; set; } = string.Empty;
        protected string Entidad { get; set; } = string.Empty;
    }

    public class Motor : Componente
    {
        public int? Aeronave { get; set; }
        public Decimal TiempoTotal { get; set; }
        public Decimal TURM { get; set; }
    }

    public class Helice : Componente
    {
        public Decimal TiempoTotal { get; set; }
        public Decimal TURM { get; set; }
    }

    public class OtroComponente : Componente
    {
        public int? Aeronave { get; set; }
    }
}
