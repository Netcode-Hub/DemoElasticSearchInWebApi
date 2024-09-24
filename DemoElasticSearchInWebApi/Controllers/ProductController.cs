using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoElasticSearchInWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ProductService service) : ControllerBase
    {
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(Product model)
        {
           await service.IndexProductAsync(model);
            return Ok();
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetProducts()
        {
            var results = await service.GetProductsAsync();
            return Ok(results);
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<IActionResult> SearchProduct(string searchTerm)
        {
            var result = await service.SearchProduct(searchTerm);
            return Ok(result);
        }

        [HttpGet("search-wildcard/{searchTerm}")]
        public async Task<IActionResult> SearchProductWithWildCard(string searchTerm)
        {
            var result = await service.SearchProductWithWildCard(searchTerm);
            return Ok(result);
        }

        [HttpGet("fuzzy-search/{searchTerm}")]
        public async Task<IActionResult> FuzzyProductSearch(string searchTerm)
        {
            var result = await service.FuzzyProductSearch(searchTerm);
            return Ok(result);
        }
    }
}
