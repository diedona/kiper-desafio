using DDona.Kiper.Service;
using DDona.Kiper.WebApi.Config;
using DDona.Kiper.WebApi.ViewModel.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            // VALIDATE USER CREDENTIALS
            if (_usuarioService.ValidateUsernamePassword(model.Username, model.Password))
            {
                return Ok(GenerateToken(model.Username));
            }
            else
            {
                return BadRequest("Usuário e/ou senha inválidos!");
            }
        }

        private UserLoginViewModel GenerateToken(string username)
        {
            UserLoginViewModel response = new UserLoginViewModel() { Username = username, Password = null };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Value.TokenConfiguration.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, response.Username)
                }),
                Expires = DateTime.UtcNow.AddSeconds(_settings.Value.TokenConfiguration.Seconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Token = tokenHandler.WriteToken(token);

            return response;
        }
    }
}