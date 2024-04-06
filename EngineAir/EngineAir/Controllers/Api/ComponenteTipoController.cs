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
        private ResponseJS _response = new();

        public ComponenteTipoController(ComponentService service, IHubContext<ChatHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "ADM, GRL")]
        public async Task<ResponseJS> Create([FromBody] MarcaTipo MarcaTipo)
        {
            ResponseJS response = new ResponseJS()
            {
                Leyenda = "Registro correcto",
                Estado = true
            };

            try
            {
                _response = await _service.CreateBrand(MarcaTipo);
                _response.Body = JsonConvert.SerializeObject(await _service.GetMarcasMotores());

                if (MarcaTipo.ClientID != null)
                    _response.ClientID = MarcaTipo.ClientID;

                await _hubContext.Clients.All.SendAsync("CreateBrandType", _response);
                return response;
            }
            catch
            {
                response.Leyenda = "Registro fallido";
                response.Estado = false;

                return response;
            }
        }

        [HttpPost("UpdateStatus")]
        [Authorize(Roles = "ADM, GRL")]
        public async Task<ResponseJS> UpdateStatus([FromBody] UpdateStatusDTO UpdateStatusDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.Role);
            var ID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ResponseJS response = new ResponseJS()
            {
                Leyenda = "Actualización correcta",
                Estado = true
            };

            (bool OpEstado, bool status) = await _service.UpdateStatus(UpdateStatusDTO);

            if (OpEstado)
            {
                UpdateStatusDTO.Status = status;
                await _hubContext.Clients.All.SendAsync("updateStatus", UpdateStatusDTO);
            }
            else
            {
                response.Leyenda = "Actualización fallida";
                response.Estado = false;

                return response;
            }

            return response;
        }

    }
}
