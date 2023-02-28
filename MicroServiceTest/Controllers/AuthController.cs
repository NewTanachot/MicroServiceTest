using MicroServiceTest.Interfaces;
using MicroServiceTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;
        private readonly IAuthService authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            this.logger = logger;
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] loginRequest loginRequest)
        {
            var result = await authService.LoginAsync(loginRequest);
            if (result is null) 
            { 
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
