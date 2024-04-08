using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.Entities.GeneralFields;
using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns.Interfaces;
#pragma warning disable CS8602
#pragma warning disable CS8605

namespace MVC.Services.DesignPatterns.Repositories
{
    public class MarcaTipoRepository<T> : IMarcaTipo<T> where T : BrandFields, new()
    {
        private ResponseJS _alertaEstado = new();
        public MarcaTipoRepository() { }

        // OBTENER LA LISTAS DE LOS REGISTROS DEL GENÉRICO <T>
        public async Task<List<T>> GetList(DbSet<T> table)
            => await table.ToListAsync();

        // ACTUALIZAR EL ESTADO DEL REGISTRO
        public async Task<(bool, bool)> UpdateStatus(int ID, DbSet<T> table)
        {
            try
            {
                var BrandTipe = await table.FindAsync(ID);
                BrandTipe.Estado = !BrandTipe.Estado;
                return (true, BrandTipe.Estado);
            }
            catch
            {
                return (false, false);
            }
        }

        // INSERTAR UN NUEVO REGISTRO DE MARCA
        public ResponseJS Insert(MarcaTipoViewModel marca, DbSet<T> table)
        {
            if (string.IsNullOrEmpty(marca.Nombre))
            {
                _alertaEstado.Leyenda = "¡No se pueden agregar campos núlos!";
                _alertaEstado.Estado = false;

                return _alertaEstado;
            }
            
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
