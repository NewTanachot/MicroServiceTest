using System.ComponentModel.DataAnnotations;

namespace MicroServiceTest.Models
{
    public class loginRequest
    {
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
