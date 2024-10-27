using SeasoningAndCandle.Backend.Domain.Aggregates;
using SeasoningAndCandle.Backend.Infrastructure.Models;

namespace SeasoningAndCandle.Backend.Infrastructure.Mappers.Interfaces
{
    public interface IProductMapper
    {
        List<ProductsCategory> AdaptProductCategoryList(List<ProductModel> productsCategories);
    }
}
