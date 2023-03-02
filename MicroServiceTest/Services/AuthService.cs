using MicroServiceTest.Interfaces;
using MicroServiceTest.Models;
using System.Runtime.CompilerServices;

namespace MicroServiceTest.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<AuthService> logger;

        public AuthService(IHttpClientFactory httpClientFactory, ILogger<AuthService> logger) 
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:81/api/");
            this.logger = logger;
        }

        public async Task<LoginResponse?> LoginAsync(loginRequest loginRequest)
        {
            var postBody = new loginRequest 
            { 
                Email = loginRequest.Email,
                Password = loginRequest.Password
            };

            var response = await httpClient.PostAsJsonAsync("Auth/Login", postBody);

            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation(response.ToString());
                return await response.Content.ReadFromJsonAsync<LoginResponse>();    
            }
            
            logger.LogError(response.ToString());
            return null;
        }
    }
}
