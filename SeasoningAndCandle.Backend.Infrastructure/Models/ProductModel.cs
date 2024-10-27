namespace SeasoningAndCandle.Backend.Infrastructure.Models
{
    public class ProductModel
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required string ProductName { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public required string ImageUrl { get; set; }
    }
}
