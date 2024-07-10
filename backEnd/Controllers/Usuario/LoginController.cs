using APITarefas.Data.Repositories;
using APITarefas.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;

namespace APITarefas.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly UsuarioRepository _mongoDbService;
        private readonly JwtTokenService _jwtTokenService;
        private readonly JwtSettings _jwtSettings;

        public LoginController(UsuarioRepository mongoDbService, JwtTokenService jwtTokenService, JwtSettings jwtSettings)
        {
            _mongoDbService = mongoDbService;
            _jwtTokenService = jwtTokenService;
            _jwtSettings = jwtSettings;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _mongoDbService.GetUserByUsername(model.Username);
            if (user == null || user.Senha != model.Password)
            {
                return Unauthorized();
            }

            var token = _jwtTokenService.GenerateToken(user);

            var response = new LoginResponse
            {
                Access_Token = token,
                Token_Type = "bearer",
                Expires_In = (int)TimeSpan.FromMinutes(_jwtSettings.ExpiresInMinutes).TotalSeconds
            };

            return Ok(response);
        }
    }
}


