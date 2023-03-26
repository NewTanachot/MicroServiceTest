using MicroServiceTest.Interfaces;
using MicroServiceTest.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

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
            //httpClient.BaseAddress = new Uri("http://localhost:81/api/");
            httpClient.BaseAddress = new Uri("http://192.168.1.44/api/");
        }

        public async Task<List<ProductResponse>> GetAllProductAsync()
        {
            var response = await httpClient.GetAsync("Product/GetProductForAllUser");
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
            var response = await httpClient.GetAsync("Product/GetProductForAllUser");
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

        public async Task<List<UserProductResponse>?> GetUserProductAsync(string jwt)
        {
            var objData = new List<UserProductResponse>();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            var response = await httpClient.GetAsync("Product/GetProduct");

            if (response.IsSuccessStatusCode)
            {
                objData = await response.Content.ReadFromJsonAsync<List<UserProductResponse>>() ?? new List<UserProductResponse>();
            }
            else if ((int)response.StatusCode == 401)
            {
                return null;
            }

            logger.LogInformation(objData.ToString());
            return objData;
        }
    }
}
