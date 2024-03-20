using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.Entities.GeneralFields;
using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns.Interfaces;
#pragma warning disable CS8602
#pragma warning disable CS8605

namespace MVC.Services.DesignPatterns.Repositories
{
    public class MarcaTipoRepository <T> : IMarca<T> where T : BrandFields, new()
    {
        private ResponseJS _alertaEstado = new();
        public MarcaTipoRepository() {  }

        // OBTENER LA LISTAS DE LOS REGISTROS DEL GENÉRICO <T>
        public async Task<List<T>> GetList(DbSet<T> table)
            => await table.ToListAsync();

        // INSERTAR UN NUEVO REGISTRO DE MARCA
        public ResponseJS Insert(MarcaTipo marca, DbSet<T> table) 
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
