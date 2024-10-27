using DataAbstractions.Dapper;
using SeasoningAndCandle.Backend.Domain.Aggregates;
using SeasoningAndCandle.Backend.Domain.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.Mappers.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.Models;

namespace SeasoningAndCandle.Backend.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbProvider _dbProvider;
        private readonly IProductMapper _productMapper;
        public ProductRepository(IDbProvider dbProvider, IProductMapper productMapper)
        {
            _dbProvider = dbProvider;
            _productMapper = productMapper;
        }
        public async Task<List<ProductsCategory>> GetProductsAsync(int limit)
        {
            var sql = @"WITH ProductsByCategory AS (
                            SELECT 
                                P.ProductId,
                                C.CategoryId,
                                C.Name AS CategoryName,
                                P.Name AS ProductName,
		                        P.Description,
		                        P.Price,
                                P.Stock,
                                P.ImageUrl,
                                ROW_NUMBER() OVER (PARTITION BY C.CategoryId ORDER BY P.ProductId) AS ProducRow
                            FROM ProductCategories AS PC
                            INNER JOIN Categories AS C 
                            ON PC.CategoryCode = C.CategoryId
                            INNER JOIN Products AS P 
                            ON PC.ProductCode = P.ProductId
                        )
                        SELECT 
                            ProductId,
                            CategoryId,
                            CategoryName,
                            ProductName,
	                        Description,
	                        Price,
                            Stock,
                            ImageUrl
                        FROM ProductsByCategory
                        WHERE ProducRow <= @NProcductsByCategory";

            using IDataAccessor connection = _dbProvider.GetConnectionString();
            IEnumerable<ProductModel> productsModel = await connection.QueryAsync<ProductModel>(sql, new { NProcductsByCategory = limit });

            return _productMapper.AdaptProductCategoryList(productsModel.ToList());
        }
    }
}
