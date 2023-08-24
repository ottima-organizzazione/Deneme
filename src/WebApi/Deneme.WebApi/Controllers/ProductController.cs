using Deneme.Application.Dtos;
using Deneme.Domain.Entities;
using Deneme.Infrastrucute.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Persistance.Context;

namespace Deneme.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;

        public ProductController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet("GetProductList")]
        public Task<List<Product>> GetProducts()
        {
            var products = _productService.GetProductList();

            return products;
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var data = _productService.GetProductById(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequest product)
        {
            Task<Product> response = _productService.InsertProduct(product);

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] UpdateRequest product)
        {

            Task<Product> response = _productService.UpdateProduct(product);

            return Ok(response);

        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int Id)
        {

            Task<bool> data = _productService.DeleteProduct(Id);

            if (data.IsFaulted)
            {
                return NotFound();
            }
            return Ok();


        }

    }
}
