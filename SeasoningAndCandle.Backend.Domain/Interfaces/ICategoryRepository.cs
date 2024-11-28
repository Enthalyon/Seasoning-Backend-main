using SeasoningAndCandle.Backend.Domain.Entities;

namespace SeasoningAndCandle.Backend.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryByCodeAsync(Guid code);
        Task<Category> GetCategoriesAsync();
    }
}
