using EngineAir.Models;
using MVC.Models.Classes;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Services.DesignPatterns.Repositories
{
    public class MotorRepository
    {
        private readonly Context _context;
        private ResponseJS _alertaEstado = new();
        public MotorRepository(Context context) { _context = context; }

        public ResponseJS Insert(MotorViewModel model)
        {
            try
            {
                Motor motor = new()
                {
                    ModeloID = model.ModeloVarianteID,
                    Funcional = model.Estado,
                    NumSerie = model.NumSerie,
                    TiempoTotal = model.TiempoTotal,
                    TURM = model.TURM
                };

                if (model.HeliceID != null)
                {
                    HistorialMotorHelice motorHelice = new()
                    {
                        Motor = motor,
                        HeliceID = model.HeliceID ?? 0,
                        Estado = true
                    };

                    if (model.AeronaveID != null)
                        motorHelice.AeronaveID = model.AeronaveID;

                    _context.Add(motorHelice);
                }
                _context.Add(motor);

                _alertaEstado.Leyenda = "Datos registrados correctamente";
                _alertaEstado.Estado = true;
            }
            catch
            {
                _alertaEstado.Leyenda = "¡Ocurrio un error interno en el servidor!";
                _alertaEstado.Estado = false;
            }

            return _alertaEstado;
        }

    }
}
