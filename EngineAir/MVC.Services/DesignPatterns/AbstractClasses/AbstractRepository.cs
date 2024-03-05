using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;
using MVC.Models.Entities.GeneralFields;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.DesignPatterns.Interfaces;

namespace MVC.Services.DesignPatterns.AbstractClasses
{
    // Clase base de los repositorios
    public abstract class AbstractRepository
    {
        protected readonly Context _context;
        protected AlertaEstado _alertaEstado;
        public AbstractRepository(Context context)
        {
            _context = context;
            _alertaEstado = new AlertaEstado();
        }
    } 
}
