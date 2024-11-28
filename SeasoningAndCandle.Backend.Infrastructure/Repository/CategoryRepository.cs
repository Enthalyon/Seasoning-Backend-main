using DataAbstractions.Dapper;
using Mapster;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.DbProvider;
using SeasoningAndCandle.Backend.Infrastructure.Models;

namespace SeasoningAndCandle.Backend.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        //1. Inyectar IDbProvider
        private readonly IDbProvider _dbProvider;
        public CategoryRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {

            //2. Hacer la sentencia de inserción
            string sql = "INSERT INTO Categories (Code, Name, Description) VALUES (@Code, @Name, @Description)";

            //3 Maper al modelo de la base datos
            CategoryModel categoryModel = category.Adapt<CategoryModel>();

            //4. Obtener la conexión con IDbProvider
            using IDataAccessor connection = _dbProvider.GetConnectionString();

            //5. Mandar a crear la categoria
            int result = await connection.ExecuteAsync(sql, categoryModel);

            //6. Si el resultado es mayor, es decir que afecto por lo menos una fila seguimos la ejecución
            //   sino, hacemos un throw exception

            if ( result == 0 )
            {
                throw new Exception("Ha ocurrido un error al crear la categoria");
            }

            //7. Consultamos la categoría para obtener su Code
            string getCategorySqlQuery = "SELECT CategoryId FROM Categories WHERE Code LIKE @Code";
            long categoryId = await connection.QueryFirstOrDefaultAsync<long>(getCategorySqlQuery, new { categoryModel.Code });

            //8. Retornamos la categoria mapeada al modelo Category
            return new Category
            {
                Id = categoryId,
                Code = categoryModel.Code,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
        }

        public async Task<Category> GetCategoriesAsync()
        {
            string getCategories = "SELECT * FROM Categories";
            using IDataAccessor connection = _dbProvider.GetConnectionString();
            CategoryModel categoryModel = await connection.QueryFirstOrDefaultAsync<CategoryModel>(getCategories);
            if ( categoryModel == null )
            {
                throw new Exception("No esxiste ninguna categoria");
            }

            return new Category
            {
                Id = categoryModel.CategoryId,
                Code = categoryModel.Code,
                Name = categoryModel.Name,
                Description = categoryModel.Description

            };
        }

        public async Task<Category> GetCategoryByCodeAsync(Guid code)
        {
            string getCategoryByCode = "SELECT * FROM Categories WHERE Code LIKE @Code";            

            using IDataAccessor connection = _dbProvider.GetConnectionString();

            CategoryModel categoryModel = await connection.QueryFirstOrDefaultAsync<CategoryModel>(getCategoryByCode, new { Code = code });

            if (categoryModel is null)
            {
                throw new Exception("la categoria no existe");
            }

            return new Category 
            {
                Id = categoryModel.CategoryId,
                Code = categoryModel.Code,
                Name = categoryModel.Name,
                Description = categoryModel.Description
            };
        }

    }
}
