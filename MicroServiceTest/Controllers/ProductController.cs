using MicroServiceTest.Interfaces;
using MicroServiceTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService<ProductResponse> productService;

        public ProductController(ILogger<ProductController> logger, IProductService<ProductResponse> productService)
        {
            this.logger = logger;
            this.productService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductFromAPIAsync()
        {
            return Ok(await productService.GetAllProductAsync());
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetGenericProductFromAPIAsync()
        {
            return Ok(await productService.GetGenericProductAsync());
        }
    }
}
