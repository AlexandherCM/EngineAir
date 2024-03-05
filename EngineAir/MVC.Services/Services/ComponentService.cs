using Microsoft.Extensions.Configuration;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.DesignPatterns;

namespace MVC.Services.Services
{
    // El servicio juntará todos los conceptos que componen a un componente
    // (Marca/Tipo, Modelo/Variante, Componente)
    public class ComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ComponentViewModel _viewModel = new();

        private AlertaEstado _alertaEstado = new();

        public ComponentService(IUnitOfWork uniOfWork, IConfiguration config)
        {
            _unitOfWork = uniOfWork;
        }

        public async Task<AlertaEstado> CreateBrand(MarcaTipo marca)
        {
            _alertaEstado.Leyenda = "Los datos ingresados no corresponden con el formato correcto";
            _alertaEstado.Estado = false;

            switch (marca.Entidad)
            {
                case "MarcaMotor":
                    this._alertaEstado = _unitOfWork.MarcaMotor.Insert(marca, _unitOfWork._context.MarcaMotor);
                    break;
                case "MarcaHelice":
                    this._alertaEstado = _unitOfWork.MarcaHelice.Insert(marca, _unitOfWork._context.MarcaHelice);
                    break;
                case "Tipo":
                    this._alertaEstado = _unitOfWork.TipoComponente.Insert(marca, _unitOfWork._context.TipoComponente);
                    break;
                default:
                    return _alertaEstado;
            }

            await _unitOfWork.Save();
            return _alertaEstado;
        } 
    }
}
