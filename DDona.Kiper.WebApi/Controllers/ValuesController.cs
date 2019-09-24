using DDona.Kiper.WebApi.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DDona.Kiper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOptions<AppSettings> _settings;

        public ValuesController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { text = _settings.Value.ApplicationName });
        }
    }
}
