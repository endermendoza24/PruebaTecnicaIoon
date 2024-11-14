using IoonSistema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;

namespace IoonSistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IConfiguration _configuration;

        // Definir el GUID correspondiente al estado "Active"
        private readonly Guid ActiveStateId = new Guid("BAD80CC4-07DF-446D-94FA-93445188BEE3");

        public AuthController(AuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                // Buscar al usuario por su nombre de usuario
                var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Username = @Username", new { Username = loginRequest.Username });

                if (user == null || user.Password != loginRequest.Password)
                {
                    return Unauthorized("Usuario o contraseña incorrectos");
                }

                // Verificar que el estado del usuario sea "Active"
                if (user.State != ActiveStateId)
                {
                    return Unauthorized("El usuario no está activo");
                }

                // Generar el JWT
                var token = _authService.GenerateJwtToken(user.UserId, user.Role);

                return Ok(new { Token = token });
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
