using DataAbstractions.Dapper;
using Mapster;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;
using SeasoningAndCandle.Backend.Infrastructure.Models;
using System.Data.SqlClient;

namespace SeasoningAndCandle.Backend.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbProvider _dbProvider;
        public UserRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }
        public async Task<User> FindByEmailAsync(string email)
        {
            var sql = "select * from users where email = @Email";

            using IDataAccessor connection = _dbProvider.GetConnectionString();
            UserModel userModel = await connection.QueryFirstOrDefaultAsync<UserModel>(sql, new { Email = email });

            return userModel.Adapt<User>();
        }
        public async Task<bool> RegisterUserAsync(User user)
        {
            var sql = "insert into users (FirstName, LastName, Phone, Email, Address, Password, IsActive, CreatedAt) values (@FirstName, @LastName, @Phone, @Email, @Address, @Password, @IsActive, @CreatedAt)";
            UserModel userModel = user.Adapt<UserModel>();
            using IDataAccessor connection = _dbProvider.GetConnectionString();
            int result = await connection.ExecuteAsync(sql, userModel);
            return result > 0;
        }
    }
}
