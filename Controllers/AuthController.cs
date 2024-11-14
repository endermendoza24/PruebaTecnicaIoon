using Microsoft.AspNetCore.Mvc;
using IoonSistema;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Linq;

namespace IoonSistema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly Database _database;

        public AuthController(AuthService authService, Database database)
        {
            _authService = authService;
            _database = database;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Conectar a la base de datos y verificar las credenciales
            using (var connection = _database.GetConnection())
            {
                var user = connection.QueryFirstOrDefault<User>(
                    "SELECT * FROM Users WHERE Username = @Username",
                    new { Username = loginRequest.Username });

                // Verificar si el usuario existe y si la contraseña es correcta
                if (user == null || user.Password != loginRequest.Password)
                {
                    return Unauthorized("Invalid credentials");
                }

                // Genera el token JWT
                var token = _authService.GenerateJwtToken(loginRequest.Username, user.Role);

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
