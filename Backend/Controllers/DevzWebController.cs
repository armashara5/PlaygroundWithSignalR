using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevzWebController : ControllerBase
    {

        private readonly ILogger<DevzWebController> _logger;

        public DevzWebController(ILogger<DevzWebController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "Off_Screen"), Route("Off")]
        //public PageContent Off()
        //{
        //    return new PageContent
        //    {
        //        Text = "Off"
        //    };
        //}

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


            // Create an HttpClient instance
            HttpClient client = new HttpClient();

            // Set the base address
            client.BaseAddress = new Uri("https://localhost:7121/");

            // Set the accept header to JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Send a POST request to the mvc application with the message_from_winform object
            HttpResponseMessage response = await client.PostAsJsonAsync("Home/ReceiveMessage", message_from_winform);

            // Check the response status code and read the content
            if (response.IsSuccessStatusCode)
            {
                // Read the response as a string
                string result = await response.Content.ReadAsStringAsync();

                //// Update the view with the result
                //$("#message").html(result);

                //// Read the response as a string
                //string result = await response.Content.ReadAsStringAsync();

                //// Do something with the result
                return Ok(result);
                ////Console.WriteLine(result);
            }
            else
            {
                // Handle the error
                //Console.WriteLine(response.StatusCode);
                return BadRequest(response.StatusCode);
            }

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