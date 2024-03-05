namespace MVC.Models.ViewModels
{
    public class ComponentViewModel
    {
        public MarcaTipo MarcaTipo { get; set; } = new();
        public ModeloVariante ModeloVariante { get; set; } = new();
        public Motor Motor { get; set; } = new();
        public Helice Helice { get; set; } = new();
        public OtroComponente OtroComponente { get; set; } = new();
    }

    public class MarcaTipo
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public string Entidad { get; set; } = string.Empty; 
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
