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
    public class SaleController : ControllerBase
    {
        private readonly Database _database;

        public SaleController(Database database)
        {
            _database = database;
        }

        // GET api/sale
        [HttpGet]
        public IActionResult GetAllSales()
        {
            using (var connection = _database.GetConnection())
            {
                var sales = connection.Query<Sale>("SELECT * FROM Sales");
                return Ok(sales);
            }
        }

        // GET api/sale/{id}
        [HttpGet("{id}")]
        public IActionResult GetSaleById(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var sale = connection.QueryFirstOrDefault<Sale>("SELECT * FROM Sales WHERE SaleId = @Id", new { Id = id });
                if (sale == null)
                {
                    return NotFound();
                }
                return Ok(sale);
            }
        }

        // POST api/sale
        [HttpPost]
        public IActionResult AddSale([FromBody] Sale sale)
        {
            using (var connection = _database.GetConnection())
            {
                var query = "INSERT INTO Sales (SaleId, SaleDate, UserId, CommerceId, State) VALUES (@SaleId, @SaleDate, @UserId, @CommerceId, @State)";
                connection.Execute(query, sale);
                return CreatedAtAction(nameof(GetSaleById), new { id = sale.SaleId }, sale);
            }
        }

        // PUT api/sale/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSale(Guid id, [FromBody] Sale sale)
        {
            using (var connection = _database.GetConnection())
            {
                var existingSale = connection.QueryFirstOrDefault<Sale>("SELECT * FROM Sales WHERE SaleId = @Id", new { Id = id });
                if (existingSale == null)
                {
                    return NotFound();
                }

                var query = "UPDATE Sales SET SaleDate = @SaleDate, UserId = @UserId, CommerceId = @CommerceId, State = @State WHERE SaleId = @SaleId";
                connection.Execute(query, new { SaleId = id, sale.SaleDate, sale.UserId, sale.CommerceId, sale.State });

                return NoContent();
            }
        }

        // DELETE api/sale/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSale(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var sale = connection.QueryFirstOrDefault<Sale>("SELECT * FROM Sales WHERE SaleId = @Id", new { Id = id });
                if (sale == null)
                {
                    return NotFound();
                }

                var query = "DELETE FROM Sales WHERE SaleId = @SaleId";
                connection.Execute(query, new { SaleId = id });

                return NoContent();
            }
        }
    }
}
