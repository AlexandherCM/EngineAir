namespace MVC.Models.ViewModels
{
    public class ComponentViewModel
    {
        public MarcaTipoDTO MarcaTipo { get; set; } = new();
        public ModeloVarianteDTO ModeloVariante { get; set; } = new();
        public MotorDTO Motor { get; set; } = new();
        public HeliceDTO Helice { get; set; } = new();
        public OtroComponenteDTO OtroComponente { get; set; } = new();
    }

    public class MarcaTipoDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public string Entidad { get; set; } = string.Empty; 
    }


    public class ModeloVarianteDTO
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

    public class MotorDTO : Componente
    {
        public int? Aeronave { get; set; }
        public Decimal TiempoTotal { get; set; }
        public Decimal TURM { get; set; }
    }

    public class HeliceDTO : Componente
    {
        public Decimal TiempoTotal { get; set; }
        public Decimal TURM { get; set; }
    }

    public class OtroComponenteDTO : Componente
    {
        public int? Aeronave { get; set; }
    }
}
