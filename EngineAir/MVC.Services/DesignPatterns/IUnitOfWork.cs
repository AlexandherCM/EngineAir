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
        public Task Save();
    }
}
