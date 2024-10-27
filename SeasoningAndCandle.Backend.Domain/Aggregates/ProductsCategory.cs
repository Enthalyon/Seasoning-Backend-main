using SeasoningAndCandle.Backend.Domain.Entities;

namespace SeasoningAndCandle.Backend.Domain.Aggregates
{
    public class ProductsCategory
    {
        public long CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required List<ProductCategory> Products { get; set; }
    }
}
