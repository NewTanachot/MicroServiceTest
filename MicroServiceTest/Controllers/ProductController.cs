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
        private readonly IAuthService authService;

        public ProductController(ILogger<ProductController> logger, IProductService<ProductResponse> productService, IAuthService authService)
        {
            this.logger = logger;
            this.productService = productService;
            this.authService = authService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductFromAPI()
        {
            return Ok(await productService.GetAllProductAsync());
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetGenericProductFromAPI()
        {
            return Ok(await productService.GetGenericProductAsync());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserProductAPI()
        {
            var jwt = await authService.LoginAsync(new loginRequest
            {
                Email = "user@example.com",
                Password = "string"
            }) ?? new LoginResponse();

            var result = await productService.GetUserProductAsync(jwt.AccessToken ?? string.Empty);
            
            if (result == null)
            {
                return Unauthorized("Maybe invalid token.");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("[action]/{jwt}")]
        public async Task<IActionResult> GetUserProductAPI(string jwt)
        {
            var result = await productService.GetUserProductAsync(jwt);

            if (result == null)
            {
                return Unauthorized("Maybe invalid token.");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
