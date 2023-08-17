using Deneme.Application.Dtos;
using Deneme.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistance.Context;

namespace Deneme.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProductList")]
        public List<Product> GetProducts()
        {
            var products = _context.Products.ToList();

            return products;
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var data = _context.Products.FirstOrDefault(p => p.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequest product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var entity = new Product()
            {
                Sku = product.Sku,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockCount = product.StockCount,

            };

            Product response = _context.Add(entity).Entity;
            _context.SaveChanges();

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateRequest product)
        {
            var data = _context.Set<Product>().FirstOrDefault(p => p.Id == product.Id);

            if (data == null)
            {
                return NotFound();
            }

            data.Price = product.Price;
            data.StockCount = product.StockCount;
            data.UpdatedDate = DateTime.UtcNow;

            Product response = _context.Update(data).Entity;
            _context.SaveChanges();

            return Ok(response);

        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int Id) {

            var data = _context.Set<Product>().FirstOrDefault(p => p.Id == Id);

            if (data == null)
            {
                return NotFound();
            }
            data.IsActive = false;

            _context.Update(data);
            _context.SaveChanges();

            return Ok();


        }

    }
}
