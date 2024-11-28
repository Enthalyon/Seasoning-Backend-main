namespace SeasoningAndCandle.Backend.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public Guid Code { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
