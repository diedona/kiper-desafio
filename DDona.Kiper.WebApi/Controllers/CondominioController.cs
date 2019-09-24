using DDona.Kiper.Service;
using DDona.Kiper.WebApi.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDona.Kiper.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private readonly ICondominioService _condominioService;

        public CondominioController(ICondominioService condominioService)
        {
            _condominioService = condominioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_condominioService.GetAll());
        }

        [HttpGet]
        [Route("saudacao")]
        public IActionResult GetSaudacao()
        {
            return Ok($"Olá {this.User.GetUsername()}! Você é um '{this.User.GetRole()}'");
        }
    }
}