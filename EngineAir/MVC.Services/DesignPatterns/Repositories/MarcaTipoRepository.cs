using EngineAir.Models;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Entities;
using MVC.Models.Entities.GeneralFields;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.DesignPatterns.AbstractClasses;
using MVC.Services.DesignPatterns.Interfaces;
#pragma warning disable CS8602
#pragma warning disable CS8605

namespace MVC.Services.DesignPatterns.Repositories
{
    public class MarcaTipoRepository <T> : AbstractRepository, IMarca<T> where T : BrandFields, new()
    { 
        public MarcaTipoRepository(Context context) : base(context) { }
        public AlertaEstado Insert(MarcaTipoDTO marca, DbSet<T> table) 
        {
            if (table.Any(e => e.Nombre == marca.Nombre))
            {
                _alertaEstado.Leyenda = "¡Ya existe una marca con ese nombre!";
                _alertaEstado.Estado = false;

                return _alertaEstado;
            }

            try
            {
                T model = new()
                {
                    Nombre = marca.Nombre,
                    Estado = marca.Estado,
                };

                table.Add(model);

                _alertaEstado.Leyenda = "Datos registrados correctamente";
                _alertaEstado.Estado = true;

                return _alertaEstado;
            }
            catch (Exception ex)
            {
                _alertaEstado.Leyenda = ex.Message;
                _alertaEstado.Estado = false;

                return _alertaEstado;
            }
        }
    }
}
