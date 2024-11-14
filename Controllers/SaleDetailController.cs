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
    public class SaleDetailController : ControllerBase
    {
        private readonly Database _database;

        public SaleDetailController(Database database)
        {
            _database = database;
        }

        // GET api/saledetail
        [HttpGet]
        public IActionResult GetAllSaleDetails()
        {
            using (var connection = _database.GetConnection())
            {
                var saleDetails = connection.Query<SaleDetail>("SELECT * FROM SaleDetails");
                return Ok(saleDetails);
            }
        }

        // GET api/saledetail/{id}
        [HttpGet("{id}")]
        public IActionResult GetSaleDetailById(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var saleDetail = connection.QueryFirstOrDefault<SaleDetail>("SELECT * FROM SaleDetails WHERE DetailId = @Id", new { Id = id });
                if (saleDetail == null)
                {
                    return NotFound();
                }
                return Ok(saleDetail);
            }
        }

        // POST api/saledetail
        [HttpPost]
        public IActionResult AddSaleDetail([FromBody] SaleDetail saleDetail)
        {
            using (var connection = _database.GetConnection())
            {
                // Verificar que la venta a la que pertenece el detalle existe
                var saleExists = connection.QueryFirstOrDefault<int>("SELECT COUNT(1) FROM Sales WHERE SaleId = @SaleId", new { SaleId = saleDetail.SaleId });
                if (saleExists == 0)
                {
                    return BadRequest("La venta especificada no existe.");
                }

                var query = "INSERT INTO SaleDetails (DetailId, SaleId, Product, Quantity, Price) VALUES (@DetailId, @SaleId, @Product, @Quantity, @Price)";
                connection.Execute(query, saleDetail);

                return CreatedAtAction(nameof(GetSaleDetailById), new { id = saleDetail.DetailId }, saleDetail);
            }
        }

        // PUT api/saledetail/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSaleDetail(Guid id, [FromBody] SaleDetail saleDetail)
        {
            using (var connection = _database.GetConnection())
            {
                var existingSaleDetail = connection.QueryFirstOrDefault<SaleDetail>("SELECT * FROM SaleDetails WHERE DetailId = @Id", new { Id = id });
                if (existingSaleDetail == null)
                {
                    return NotFound();
                }

                var query = "UPDATE SaleDetails SET SaleId = @SaleId, Product = @Product, Quantity = @Quantity, Price = @Price WHERE DetailId = @DetailId";
                connection.Execute(query, new { SaleId = saleDetail.SaleId, saleDetail.Product, saleDetail.Quantity, saleDetail.Price, DetailId = id });

                return NoContent();
            }
        }

        // DELETE api/saledetail/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSaleDetail(Guid id)
        {
            using (var connection = _database.GetConnection())
            {
                var saleDetail = connection.QueryFirstOrDefault<SaleDetail>("SELECT * FROM SaleDetails WHERE DetailId = @Id", new { Id = id });
                if (saleDetail == null)
                {
                    return NotFound();
                }

                var query = "DELETE FROM SaleDetails WHERE DetailId = @DetailId";
                connection.Execute(query, new { DetailId = id });

                return NoContent();
            }
        }
    }
}
