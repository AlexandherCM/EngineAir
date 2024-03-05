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

        private readonly IConfiguration _config;
        private string MarcaMotor;
        private string MarcaHelice;
        private string MarcaOtro;
        private AlertaEstado _alertaEstado = new();

        public ComponentService(IUnitOfWork uniOfWork, IConfiguration config)
        {
            _unitOfWork = uniOfWork;

            _config = config;
            MarcaMotor = _config["Concept:Engine:Brand"];
            MarcaHelice = _config["Concept:Propeller:Brand"];
            MarcaOtro = _config["Concept:Component:Brand"];
        }

        public async Task<AlertaEstado> CreateBrand(MarcaTipoDTO marca)
        {
            if (marca.Entidad == MarcaMotor)
                this._alertaEstado = _unitOfWork.MarcaMotor.Insert(marca, _unitOfWork._context.MarcaMotor);

            else if (marca.Entidad == MarcaHelice)
                this._alertaEstado = _unitOfWork.MarcaHelice.Insert(marca, _unitOfWork._context.MarcaHelice);

            else if (marca.Entidad == MarcaOtro)
                this._alertaEstado = _unitOfWork.TipoComponente.Insert(marca, _unitOfWork._context.TipoComponente);

            await _unitOfWork.Save();
            return _alertaEstado;
        } 
    }
}
