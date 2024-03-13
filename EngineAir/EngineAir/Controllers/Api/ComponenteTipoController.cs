using EngineAir.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC.Services.Classes;
using MVC.Services.Services;

namespace EngineAir.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponenteTipoController : ControllerBase
    {
        private ComponentService _service;
        private IHubContext<ChatHub> _hubContext;
        private AlertaEstado _alertaEstado = new();

        public ComponenteTipoController(ComponentService service, IHubContext<ChatHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;
        }

        //[HttpGet("GetMotores")]
        //public async Task<IActionResult> GetMotores([FromBody] MarcaTipo MarcaTipo)
        //{
        //    //_alertaEstado = await _service.CreateBrand(MarcaTipo);

        //    //await _hubContext.Clients.All.SendAsync("sendMessage", Json);
        //    return Ok();
        //} 

    }
}
