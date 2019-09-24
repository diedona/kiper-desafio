using DDona.Kiper.Service;
using DDona.Kiper.WebApi.Config;
using DDona.Kiper.WebApi.ViewModel.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DDona.Kiper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IUsuarioService _usuarioService;

        public LoginController(IOptions<AppSettings> settings, IUsuarioService usuarioService)
        {
            _settings = settings;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Post(UserLoginViewModel model)
        {
            return Ok(_usuarioService.GetAll());
        }
    }
}