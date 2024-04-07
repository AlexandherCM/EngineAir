using EngineAir.Hubs;
using EngineAir.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MVC.Models.Classes;
using MVC.Models.ViewModels;
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

        private ResponseJS _observerResponse = new();
        private ResponseJS _code200 = new()  
        {
            Leyenda = "Consulta exitosa al servidor.", 
            Estado = true
        }; 
        
        private ResponseJS _code500 = new()  
        {
            Leyenda = "Ocurrió un error interno en el servidor.", 
            Estado = true
        }; 

        public ComponenteTipoController(ComponentService service, IHubContext<ChatHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADM, GRL")]
        public async Task<ResponseJS> Create([FromBody] MarcaTipo MarcaTipo)
        {
            try
            {
                _observerResponse = await _service.CreateBrand(MarcaTipo);
                if (_observerResponse.Estado)
                {
                    switch (MarcaTipo.Entidad)
                    {
                        case "MarcaMotor":
                            this._observerResponse.Body = JsonConvert.SerializeObject(await _service.GetMarcasMotores());
                            break;
                        case "MarcaHelice":
                            this._observerResponse.Body = JsonConvert.SerializeObject(await _service.GetMarcasHelices());
                            break;
                        case "Tipo":
                            this._observerResponse.Body = JsonConvert.SerializeObject(await _service.GetTiposComponente());
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
        [Authorize(Roles = "ADM, GRL")]
        public async Task<ResponseJS> UpdateStatus([FromBody] UpdateStatusDTO UpdateStatusDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.Role);
            var ID = User.FindFirstValue(ClaimTypes.NameIdentifier);

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

    }
}
