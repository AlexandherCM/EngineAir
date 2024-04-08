using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.Entities.GeneralFields;
using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVC.Services.DesignPatterns.Repositories
{
    public class ModelVariantRepository<T> : IModelVariant<T> where T : ModalFields, new()
    {
        private ResponseJS _alertaEstado = new();
        public ModelVariantRepository() { }
         
        public ResponseJS Insert(ModeloVariante ModeloVariante, DbSet<T> table)
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
