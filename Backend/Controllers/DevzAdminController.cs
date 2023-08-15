using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevzAdminController : ControllerBase
    {

        private readonly ILogger<DevzAdminController> _logger;

        public DevzAdminController(ILogger<DevzAdminController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetDevzAdmin")]
        //public IEnumerable<DevzAdmin> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new DevzAdmin
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet, Route("GetWF")]
        //public IEnumerable<DevzAdmin> GetWF()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new DevzAdmin
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}