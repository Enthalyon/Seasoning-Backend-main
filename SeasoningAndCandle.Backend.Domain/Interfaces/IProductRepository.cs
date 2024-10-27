using SeasoningAndCandle.Backend.Domain.Aggregates;

namespace SeasoningAndCandle.Backend.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductsCategory>> GetProductsAsync(int limit);
    }
}
