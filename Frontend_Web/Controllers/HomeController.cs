using Backend;
using Frontend_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Frontend_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(HttpClient httpClient, ILogger<HomeController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Welcome()
        {
            var response = await _httpClient.GetAsync("https://localhost:7088/DevzWeb/Welcome");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<PageContent>(responseBody);
            if (content != null)
            {
                ViewBag.PageContent = content.Text;
                ViewBag.TextFormat = content.TextFormat;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Welcome(string message_from_backend)
        {
            //var response = await _httpClient.GetAsync("https://localhost:7088/DevzWeb/Welcome");
            //response.EnsureSuccessStatusCode();
            //var responseBody = await response.Content.ReadAsStringAsync();
            //var content = JsonConvert.DeserializeObject<PageContent>(responseBody);
            //if (content != null)
            //{
            //    ViewBag.PageContent = content.Text;
            //    ViewBag.TextFormat = content.TextFormat;
            //}
            ViewBag.PageContent = message_from_backend;
            return View();
        }



        [HttpGet]
        public IActionResult ReceiveMessage()
        {

            ViewBag.PageContent = "Default";
            ViewBag.TextFormat = new TextFormat
            {
                ColorValue = "Green",
                ColorSystem = "Named",
                FontStyle = "Regular",
                FontName = "Arial",
                FontWeight = 400,
                FontSize = 28
            };
            if (TempData["PageContent"] != null)
            {
                //ModelState.Clear();
            ViewBag.PageContent = TempData["PageContent"];

                    //string? message = TempData["PageContent"] as string;
                    //return PartialView("_Message", message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult ReceiveMessage([FromBody] PageContent message)
        {
            // Set the ViewBag.PageContent variable to the message object
            //ViewBag.PageContent = message.Text;
            //TempData["PageContent"] = message.Text;
            //// Return a view or a result
            ////return View("Welcome");
            //return PartialView("_Message", message);
            ////return Ok(message);
            ViewBag.PageContent = message.Text;
            TempData["PageContent"] = message.Text;
            //return View(message.Text);
            //return new ViewResult();
            return RedirectToAction("ReceiveMessage");
            //return Ok(message);
        }
    }
}