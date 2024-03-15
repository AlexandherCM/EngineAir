using EngineAir.Hubs;
using EngineAir.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC.Models.Classes;
using MVC.Models.ViewModels;
using MVC.Services.Services;
using Newtonsoft.Json;

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

            await _hubContext.Clients.All.SendAsync("sendMessage", _response); 
            return Ok();
        }

    }
}
