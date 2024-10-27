namespace SeasoningAndCandle.Backend.Application.ViewModels
{
    public class ProductsCategoryViewModel
    {
        public long CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public required List<ProductCategoryViewModel> Products { get; set; }
    }

    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required decimal Price { get; set; }
        public required int Stock { get; set; }
    }
}
