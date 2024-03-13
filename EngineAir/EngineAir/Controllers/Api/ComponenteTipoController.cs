using EngineAir.Hubs;
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

        [HttpPost("GetMotores")]
        public async Task<IActionResult> GetMotores([FromBody] MarcaTipo MarcaTipo)
        {
            _response = await _service.CreateBrand(MarcaTipo);
            _response.Body = JsonConvert.SerializeObject(await _service.GetMarcasMotores());

            string Json = JsonConvert.SerializeObject(_response);

            await _hubContext.Clients.All.SendAsync("sendMessage", Json);
            return Ok();
        }

    }
}
