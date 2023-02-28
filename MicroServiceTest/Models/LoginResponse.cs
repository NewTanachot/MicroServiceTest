namespace MicroServiceTest.Models
{
    public class LoginResponse
    {
        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public string? AccessToken { get; set; }

        public DateTime? AccessToken_CreateAt { get; set; }

        public DateTime? AccessToken_ExpireAt { get; set; }
    }
}
