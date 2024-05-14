using EngineAir.Models;
using MVC.Models.Entities;
using MVC.Services.DesignPatterns.Repositories;

namespace MVC.Services.DesignPatterns
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context _context { get; }
        public MarcaTipoRepository<MarcaMotor> MarcaMotor { get;}
        public MarcaTipoRepository<MarcaHelice> MarcaHelice {get;}
        public MarcaTipoRepository<TipoComponente> TipoComponente {get;}

        public ModelVariantRepository<ModeloMotor> ModeloMotor { get; }
        public ModelVariantRepository<ModeloHelice> ModeloHelice { get; }
        public ModelVariantRepository<Variante> Variante { get; }

        public HeliceRepository Helice { get; } 

        public UnitOfWork
        (
            Context context,
            MarcaTipoRepository<MarcaMotor> MarcaMotor,
            MarcaTipoRepository<MarcaHelice> MarcaHelice,
            MarcaTipoRepository<TipoComponente> TipoComponente,
            ModelVariantRepository<ModeloMotor> ModeloMotor,
            ModelVariantRepository<ModeloHelice> ModeloHelice,
            ModelVariantRepository<Variante> Variante,
            HeliceRepository Helice
        )
        {
            _context = context;
            this.MarcaMotor = MarcaMotor;
            this.MarcaHelice = MarcaHelice;
            this.TipoComponente = TipoComponente;
            this.ModeloMotor = ModeloMotor;
            this.ModeloHelice = ModeloHelice;
            this.Variante = Variante;
            this.Helice = Helice;
        }

        public async Task Save()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
