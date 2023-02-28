using MicroServiceTest.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace MicroServiceTest.Interfaces
{
    public interface IProductService<T>
    {
        Task<List<ProductResponse>> GetAllProductAsync();

        Task<List<T>> GetGenericProductAsync();

        Task<List<UserProductResponse>?> GetUserProductAsync(string jwt);
    }
}
