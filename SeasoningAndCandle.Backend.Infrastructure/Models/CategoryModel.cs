namespace SeasoningAndCandle.Backend.Infrastructure.Models
{
    public class CategoryModel
    {
        public long CategoryId { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
