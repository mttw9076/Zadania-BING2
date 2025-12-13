using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _service.GetById(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existing = _service.GetById(id);
            if (existing is null) return NotFound();
            _service.Update(id, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _service.GetById(id);
            if (existing is null) return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}
