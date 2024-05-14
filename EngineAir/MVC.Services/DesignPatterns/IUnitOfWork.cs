using EngineAir.Models;
using MVC.Models.Entities;
using MVC.Services.DesignPatterns.Repositories;

namespace MVC.Services.DesignPatterns
{
    public interface IUnitOfWork : IDisposable
    {
        public Context _context { get; }
        public MarcaTipoRepository<MarcaMotor> MarcaMotor { get; }
        public MarcaTipoRepository<MarcaHelice> MarcaHelice { get; }  
        public MarcaTipoRepository<TipoComponente> TipoComponente { get; }

        public ModelVariantRepository<ModeloMotor> ModeloMotor { get; }
        public ModelVariantRepository<ModeloHelice> ModeloHelice { get; }
        public ModelVariantRepository<Variante> Variante { get; }
        public HeliceRepository Helice { get; } 
        public Task Save();
    }
}
