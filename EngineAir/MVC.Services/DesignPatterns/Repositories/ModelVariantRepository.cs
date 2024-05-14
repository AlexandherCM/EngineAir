using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.Entities.GeneralFields;
using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns.Interfaces;
using System.Linq.Expressions;
#pragma warning disable CS8602

namespace MVC.Services.DesignPatterns.Repositories
{
    public class ModelVariantRepository<T> : IModelVariant<T> where T : ModelFields, new()
    {
        private ResponseJS _alertaEstado = new();
        public ModelVariantRepository() { }

        //public async Task<List<T>> GetList(DbSet<T> table)
        //    => await table.ToListAsync();

        public async Task<List<T>> GetList(DbSet<T> table, params Expression<Func<T, object>>[] includes)
        {
            var query = table.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

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

        public ResponseJS Insert(ModeloVarianteViewModel ModeloVariante, DbSet<T> table)
        {
            if (table.Any(e => e.Nombre == ModeloVariante.Nombre))
            {
                _alertaEstado.Leyenda = "¡Ya existe un registro con ese nombre!";
                _alertaEstado.Estado = false;

                return _alertaEstado;
            }
            try
            {
                T model = new()
                {
                    MarcaTipoID = ModeloVariante.MarcaTipoID,
                    Nombre = ModeloVariante.Nombre,
                    TiempoRemplazoHrs = ModeloVariante.TiempoRemplazoHrs ?? 0,
                    TiempoRemplazoMeses = ModeloVariante.MesesTotales() ?? 0,
                    Estado = ModeloVariante.Estado,
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
