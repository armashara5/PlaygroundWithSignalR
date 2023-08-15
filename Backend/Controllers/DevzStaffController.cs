using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevzStaffController : ControllerBase
    {

        private readonly ILogger<DevzStaffController> _logger;

        public DevzStaffController(ILogger<DevzStaffController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetDevzStaff")]
        //public IEnumerable<DevzStaff> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new DevzStaff
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet, Route("GetWF")]
        //public IEnumerable<DevzStaff> GetWF()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new DevzStaff
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}