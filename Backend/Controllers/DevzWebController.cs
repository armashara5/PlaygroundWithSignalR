using Backend.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Http.Headers;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevzWebController : ControllerBase
    {

        private readonly ILogger<DevzWebController> _logger;
        private readonly IHubContext<PageContentHub> _hubContext;

        public DevzWebController(ILogger<DevzWebController> logger, IHubContext<PageContentHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        [HttpGet("Welcome")]
        public PageContent Welcome()
        {
            return new PageContent
            {
                Text = "Welcome to DEVZ",
                TextFormat = GetTextFormat()
            };
        
        }




        [HttpPost("PostTestMessage")]
        public async Task<IActionResult> PostTestMessage([FromBody] PageContent message_from_winform)
        {

            // Call the hub method
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message_from_winform.Text);

            // Return some result
            return Ok();
        }

        private TextFormat GetTextFormat()
        {
            var random = new Random();
            int rdm = random.Next(1,20);
            if(rdm > 10)
                return new TextFormat();

            return new TextFormat
            {
                ColorValue = "Blue",
                ColorSystem = "Named",
                FontStyle = "Bold",
                FontName = "Andalus",
                FontWeight = 900,
                FontSize = 48,
            };

        }


    }

}