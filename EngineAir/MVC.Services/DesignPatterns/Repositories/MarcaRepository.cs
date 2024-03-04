using EngineAir.Models;
using Microsoft.Extensions.Configuration;
using MVC.Models.Entities;
using MVC.Models.ViewModels;
using MVC.Services.Classes;
using MVC.Services.DesignPatterns.AbstractClasses;

namespace MVC.Services.DesignPatterns.Repositories
{
    public class MarcaRepository : AbstractRepository
    {
        private readonly IConfiguration _config;
        private string MarcaMotor;
        private string MarcaHelice;
        private string MarcaOtro; 
        public MarcaRepository(Context context, IConfiguration config) : base(context)
        {
            _config = config;
            MarcaMotor  = _config["ApiSettings:EntityEngineBrand"];
            MarcaHelice = _config["ApiSettings:EntityPropellerBrand"];
            MarcaOtro   = _config["ApiSettings:EntityOtherBrand"];
        }

        public override AlertaEstado Insert(MarcaTipoDTO marca)
        {
            return _alertaEstado;
        }
    }
}
