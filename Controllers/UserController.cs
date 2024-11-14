using Microsoft.AspNetCore.Mvc;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using IoonSistema;

namespace IoonSistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Database _database;

        public UserController(Database database)
        {
            _database = database;
        }

        // GET api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            using (var connection = _database.GetConnection())
            {
                var users = connection.Query<User>("SELECT * FROM Users");
                return Ok(users);
            }
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE UserId = @Id", new { Id = id });
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
        }

        // POST api/user
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            using (var connection = _database.GetConnection())
            {
                var query = "INSERT INTO Users (UserId, Username, Password, Role, CommerceId, State) VALUES (@UserId, @Username, @Password, @Role, @CommerceId, @State)";
                connection.Execute(query, user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
        }

        // PUT api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] User user)
        {
            using (var connection = _database.GetConnection())
            {
                var existingUser = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE UserId = @Id", new { Id = id });
                if (existingUser == null)
                {
                    return NotFound();
                }

                var query = "UPDATE Users SET Username = @Username, Password = @Password, Role = @Role, CommerceId = @CommerceId, State = @State WHERE UserId = @UserId";
                connection.Execute(query, new { UserId = id, user.Username, user.Password, user.Role, user.CommerceId, user.State });

                return NoContent();
            }
        }

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var user = connection.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE UserId = @Id", new { Id = id });
                if (user == null)
                {
                    return NotFound();
                }

                var query = "DELETE FROM Users WHERE UserId = @UserId";
                connection.Execute(query, new { UserId = id });

                return NoContent();
            }
        }
    }
}
