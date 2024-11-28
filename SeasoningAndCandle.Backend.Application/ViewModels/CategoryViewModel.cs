namespace SeasoningAndCandle.Backend.Application.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public Guid Code { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
