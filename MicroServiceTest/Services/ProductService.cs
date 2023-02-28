using MicroServiceTest.Interfaces;
using MicroServiceTest.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace MicroServiceTest.Services
{
    public class ProductService<T> : IProductService<T>
    {
        private readonly ILogger<ProductResponse> logger;
        private readonly HttpClient httpClient;

        public ProductService(ILogger<ProductResponse> logger, IHttpClientFactory httpClientFactory) 
        {
            this.logger = logger;
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<ProductResponse>> GetAllProductAsync()
        {
            var response = await httpClient.GetAsync("http://localhost:81/api/Product/GetProductForAllUser");
            var ObjData = new List<ProductResponse>();

            if (response.IsSuccessStatusCode)
            {
                //var JsonData = await response.Content.ReadAsStringAsync();
                //var ObjData = JsonConvert.DeserializeObject<List<Product>>(JsonData) ?? new List<Product>();
                ObjData = await response.Content.ReadFromJsonAsync<List<ProductResponse>>() ?? new List<ProductResponse>();
            }

            logger.LogInformation(ObjData.ToString());
            return ObjData;
        }

        public async Task<List<T>> GetGenericProductAsync()
        {
            var response = await httpClient.GetAsync("http://localhost:81/api/Product/GetProductForAllUser");
            var ObjData = new List<T>();

            if (response.IsSuccessStatusCode)
            {
                //var JsonData = await response.Content.ReadAsStringAsync();
                //var ObjData = JsonConvert.DeserializeObject<List<T>>(JsonData) ?? new List<T>();
                ObjData = await response.Content.ReadFromJsonAsync<List<T>>() ?? new List<T>();
            }

            logger.LogInformation(ObjData.ToString());
            return ObjData;
        }
    }
}
