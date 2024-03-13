using Microsoft.Extensions.Configuration;
using MVC.Models.Classes;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns;

namespace MVC.Services.Services
{
    // El servicio juntará todos los conceptos que componen a un componente
    // (Marca/Tipo, Modelo/Variante, Componente)
    public class ComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseJS _response = new();

        public ComponentService(IUnitOfWork uniOfWork, IConfiguration config)
        {
            _unitOfWork = uniOfWork;
        }

        // Lista de las marcas y/o tipos - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public async Task<List<MarcaMotor>> GetMarcasMotores()
            => await _unitOfWork.MarcaMotor.GetList(_unitOfWork._context.MarcaMotor);

        public async Task<List<MarcaHelice>> GetMarcasHelices()
            => await _unitOfWork.MarcaHelice.GetList(_unitOfWork._context.MarcaHelice);

        public async Task<List<TipoComponente>> GetTiposComponente()
            => await _unitOfWork.TipoComponente.GetList(_unitOfWork._context.TipoComponente);

        // Agregar una nueva marca y/o tipo  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
        public async Task<ResponseJS> CreateBrand(MarcaTipo marca)
        {
            marca.Nombre = marca.Nombre.Trim();

            _response.Leyenda = "Los datos ingresados no corresponden con el formato correcto";
            _response.Estado = false;

            switch (marca.Entidad)
            {
                case "MarcaMotor":
                    this._response = _unitOfWork.MarcaMotor.Insert(marca, _unitOfWork._context.MarcaMotor);
                    break;
                case "MarcaHelice":
                    this._response = _unitOfWork.MarcaHelice.Insert(marca, _unitOfWork._context.MarcaHelice);
                    break;
                case "Tipo":
                    this._response = _unitOfWork.TipoComponente.Insert(marca, _unitOfWork._context.TipoComponente);
                    break;
                default:
                    return _response;
            }

            await _unitOfWork.Save();
            return _response;
        }

        
    }
}
