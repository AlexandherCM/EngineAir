using EngineAir.Hubs;
using EngineAir.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC.Models.Classes;
using MVC.Models.ViewModels;
using MVC.Services.DesignPatterns.Interfaces;
using MVC.Services.Services;
using Newtonsoft.Json;
using System.Security.Claims;

namespace EngineAir.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponenteTipoController : ControllerBase
    {
        private ComponentService _service;
        private IHubContext<ChatHub> _hubContext;
        //private string Rol; 
        //private string UserID;

        private ResponseJS _observerResponse = new();
        private ResponseJS _code200 = new()  
        {
            Leyenda = "Consulta exitosa al servidor.", 
            Estado = true
        }; 
        
        private ResponseJS _code500 = new()  
        {
            Leyenda = "Ocurrió un error interno en el servidor.", 
            Estado = false
        }; 

        public ComponenteTipoController(ComponentService service, IHubContext<ChatHub> hubContext)
        {
            this._service = service;
            this._hubContext = hubContext;
            //this.Rol = User.FindFirstValue(ClaimTypes.Role);
            //this.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpPost("CreateBrand")]
        //[Authorize(Roles = "ADM, GRL")]
        public async Task<ResponseJS> CreateBrand([FromBody] MarcaTipoViewModel MarcaTipo)
        {
            try
            {
                _observerResponse = await _service.CreateBrand(MarcaTipo);
                if (_observerResponse.Estado)
                {
                    switch (MarcaTipo.Entidad)
                    {
                        case "MarcaMotor":
                            this._observerResponse.Body = 
                                JsonConvert.SerializeObject(await _service.GetMarcasMotores());
                            break;
                        case "MarcaHelice":
                            this._observerResponse.Body = 
                                JsonConvert.SerializeObject(await _service.GetMarcasHelices());
                            break;
                        case "Tipo":
                            this._observerResponse.Body = 
                                JsonConvert.SerializeObject(await _service.GetTiposComponente());
                            break;
                        default:
                            return _observerResponse;
                    }
                }

                if (MarcaTipo.ClientID != null)
                    _observerResponse.ClientID = MarcaTipo.ClientID;

                await _hubContext.Clients.All.SendAsync("CreateBrandType", _observerResponse);
                return _code200;
            }
            catch
            {
                return _code500;
            }
        }

        [HttpPost("UpdateStatus")]
        //[Authorize(Roles = "ADM, GRL")]  
        public async Task<ResponseJS> UpdateStatus([FromBody] UpdateStatusDTO UpdateStatusDTO)
        {
            (bool OpEstado, bool status) = await _service.UpdateStatus(UpdateStatusDTO);

            if (OpEstado)
            {
                UpdateStatusDTO.Status = status;
                await _hubContext.Clients.All.SendAsync("updateStatus", UpdateStatusDTO);
            }
            else
            {
                return _code500;
            }
             
            return _code200;
        }

        [HttpPost("CreateModelVariant")]
        //[Authorize(Roles = "ADM, GRL")] 
        public async Task<ResponseJS> CreateModelVariant([FromBody] ModeloVarianteViewModel ModeloVariante)
        {
            try
            {
                _observerResponse = await _service.CreateModel(ModeloVariante);
                if (_observerResponse.Estado)
                {
                    switch (ModeloVariante.Entidad)
                    {
                        case "ModeloMotor":
                            this._observerResponse.Body = 
                                JsonConvert.SerializeObject(await _service.GetModelosMotores());
                            break;
                        case "ModeloHelice":
                            this._observerResponse.Body = 
                                JsonConvert.SerializeObject(await _service.GetModelosHelices());
                            break;
                        case "Variante":
                            this._observerResponse.Body = 
                                JsonConvert.SerializeObject(await _service.GetVariantesComponente());
                            break;
                        default:
                            return _observerResponse;
                    }
                }

                if (ModeloVariante.ClientID != null)
                    _observerResponse.ClientID = ModeloVariante.ClientID;

                await _hubContext.Clients.All.SendAsync("CreateModelVariant", _observerResponse);
                return _code200;
            }
            catch
            {
                return _code500;
            }
        }

        [HttpPost("AddComponent")]
        //[Authorize(Roles = "ADM, GRL")]
        public async Task<ResponseJS> AddComponent([FromBody] MotorViewModel componenteViewModel)
        {
            try
            {
                _observerResponse = await _service.InsertEngine(componenteViewModel);

                if (componenteViewModel.ClientID != null)
                    _observerResponse.ClientID = componenteViewModel.ClientID;

                await _hubContext.Clients.All.SendAsync("CreateEngine", _observerResponse);
                return _code200;
            }
            catch
            {
                return _code500;
            }
        }

    }
}
