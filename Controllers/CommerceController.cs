using Microsoft.AspNetCore.Mvc;

namespace IoonSistema.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommerceController : ControllerBase
    {
        private readonly CommerceRepository _repository;

        public CommerceController(CommerceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllCommerces()
        {
            var commerces = _repository.GetAllCommerces();
            return Ok(commerces);
        }

        [HttpGet("{id}")]
        public IActionResult GetCommerceById(Guid id)
        {
            var commerce = _repository.GetCommerceById(id);
            if (commerce == null)
            {
                return NotFound();
            }
            return Ok(commerce);
        }

        [HttpPost]
        public IActionResult AddCommerce([FromBody] Commerce commerce)
        {
            _repository.AddCommerce(commerce);
            return CreatedAtAction(nameof(GetCommerceById), new { id = commerce.CommerceId }, commerce);
        }
    }

}
