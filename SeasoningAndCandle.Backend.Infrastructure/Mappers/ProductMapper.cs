using SeasoningAndCandle.Backend.Domain.Aggregates;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Infrastructure.Mappers.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.Models;

namespace SeasoningAndCandle.Backend.Infrastructure.Mappers
{
    public class ProductMapper : IProductMapper
    {
        public List<ProductsCategory> AdaptProductCategoryList(List<ProductModel> productsCategories)
        {
            List<ProductsCategory> products = productsCategories
                .GroupBy(productCategory => productCategory.CategoryId)
                .Select(categoryId => new ProductsCategory
                {
                    CategoryId = categoryId.Key,
                    CategoryName = categoryId.First().CategoryName,
                    Products = categoryId.Select(product => new ProductCategory
                    {
                        Id = product.ProductId,
                        Name = product.ProductName,
                        Description = product.Description,
                        Price = product.Price,
                        Stock = product.Stock,
                        ImageUrl = product.ImageUrl
                    }).ToList()
                }).ToList();

            return products;
        }
    }
}
