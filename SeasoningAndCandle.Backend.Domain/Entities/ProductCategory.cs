namespace SeasoningAndCandle.Backend.Domain.Entities
{
    public class ProductCategory
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
    }
}
