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
        public async Task<IActionResult> Create([FromBody] MarcaTipo MarcaTipo)
        {
            _response = await _service.CreateBrand(MarcaTipo);
            _response.Body = JsonConvert.SerializeObject(await _service.GetMarcasMotores());

            if (MarcaTipo.ClientID != null)
                _response.ClientID = MarcaTipo.ClientID;

            await _hubContext.Clients.All.SendAsync("CreateBrandType", _response);
            return Ok();
        }

        [Authorize(Roles = "ADM, GRL")]
        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusDTO UpdateStatusDTO)
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
                return BadRequest();

            return Ok();
        }

    }
}
