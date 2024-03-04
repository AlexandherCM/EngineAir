using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns;

namespace MVC.Services.Services
{
    // El servicio juntará todos los conceptos que componen a un componente
    // (Marca/Tipo, Modelo/Variante, Componente)
    public class ComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ComponentViewModel _viewModel = new();

        public ComponentService(IUnitOfWork uniOfWork)
        {
            _unitOfWork = uniOfWork;
        }

        //public ComponentViewModel InitValues()
        //{
        //    _viewModel.MarcaTipo.Entidades = _config.GetBrandEntities();
        //    return _viewModel;
        //}
    }
}
