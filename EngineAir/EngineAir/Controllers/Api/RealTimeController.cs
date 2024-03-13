using EngineAir.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace EngineAir.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealTimeController : ControllerBase
    {
        private IHubContext<ChatHub> _hubContext;
        public RealTimeController(IHubContext<ChatHub> hubContext)
        { 
            _hubContext = hubContext; 
        }

        [HttpGet("Send")]
        public async Task<IActionResult> Send(string data)
        {
            await _hubContext.Clients.All.SendAsync("sendMessage", data);
            return Ok();
        }
    }
}
