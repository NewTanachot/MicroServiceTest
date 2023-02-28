namespace MicroServiceTest.Models
{
    public class UserProductResponse
    {
        public string? ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public int? ProductAmount { get; set; }

        public DateTime? MFD { get; set; }

        public DateTime? EXD { get; set; }

        public DateTime? ProductAddDate { get; set; }
    }
}
