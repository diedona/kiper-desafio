using DDona.Kiper.Utils.HashManager;
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
            string salt = HashManager.CreateSalt();
            string hash = HashManager.CreateHash("123123", salt);
            return Ok(new { salt = salt, hash = hash });
        }
    }
}
