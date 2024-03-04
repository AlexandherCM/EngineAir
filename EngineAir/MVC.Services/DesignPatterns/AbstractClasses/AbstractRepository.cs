using EngineAir.Models;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.DesignPatterns.Interfaces;

namespace MVC.Services.DesignPatterns.AbstractClasses
{
    public abstract class AbstractRepository// Clase base de los repositorios
    {
        protected Context _context;
        protected AlertaEstado _alertaEstado;
        public AbstractRepository(Context context)
        {
            _context = context;
            _alertaEstado = new AlertaEstado();
        }

        public abstract AlertaEstado Insert(MarcaTipoDTO marca);
    } 
}
