using EShop.Application;
using EShop.Domain.Models;
using EShop.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return  _productService.GetProductById(id);
        }
        
        [HttpPost]
        public IActionResult AddProduct(
            [FromForm] int id,
            [FromForm] string name,
            [FromForm] string? ean,
            [FromForm] decimal? price,
            [FromForm] int? stock,
            [FromForm] string? sku)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Product name is required.");
            }

            var product = new Product
            {
                Id = id,
                Name = name,
                ean = ean,
                price = price,
                stock = stock,
                sku = sku,
            };

            _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
