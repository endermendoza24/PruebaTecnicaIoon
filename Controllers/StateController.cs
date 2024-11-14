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
    public class StateController : ControllerBase
    {
        private readonly Database _database;

        public StateController(Database database)
        {
            _database = database;
        }

        // GET api/state
        [HttpGet]
        public IActionResult GetAllStates()
        {
            using (var connection = _database.GetConnection())
            {
                var states = connection.Query<State>("SELECT * FROM States");
                return Ok(states);
            }
        }

        // GET api/state/{id}
        [HttpGet("{id}")]
        public IActionResult GetStateById(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var state = connection.QueryFirstOrDefault<State>("SELECT * FROM States WHERE StateId = @Id", new { Id = id });
                if (state == null)
                {
                    return NotFound();
                }
                return Ok(state);
            }
        }

        // POST api/state
        [HttpPost]
        public IActionResult AddState([FromBody] State state)
        {
            using (var connection = _database.GetConnection())
            {
                // Verificar si el nombre del estado ya existe
                var stateExists = connection.QueryFirstOrDefault<int>("SELECT COUNT(1) FROM States WHERE StateName = @StateName", new { StateName = state.StateName });
                if (stateExists > 0)
                {
                    return BadRequest("El estado con ese nombre ya existe.");
                }

                var query = "INSERT INTO States (StateId, StateName) VALUES (@StateId, @StateName)";
                connection.Execute(query, state);

                return CreatedAtAction(nameof(GetStateById), new { id = state.StateId }, state);
            }
        }

        // PUT api/state/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateState(Guid id, [FromBody] State state)
        {
            using (var connection = _database.GetConnection())
            {
                var existingState = connection.QueryFirstOrDefault<State>("SELECT * FROM States WHERE StateId = @Id", new { Id = id });
                if (existingState == null)
                {
                    return NotFound();
                }

                var query = "UPDATE States SET StateName = @StateName WHERE StateId = @StateId";
                connection.Execute(query, new { StateName = state.StateName, StateId = id });

                return NoContent();
            }
        }

        // DELETE api/state/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteState(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var state = connection.QueryFirstOrDefault<State>("SELECT * FROM States WHERE StateId = @Id", new { Id = id });
                if (state == null)
                {
                    return NotFound();
                }

                var query = "DELETE FROM States WHERE StateId = @StateId";
                connection.Execute(query, new { StateId = id });

                return NoContent();
            }
        }
    }
}
