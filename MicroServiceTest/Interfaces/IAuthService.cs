using MicroServiceTest.Models;

namespace MicroServiceTest.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(loginRequest loginRequest);
    }
}
