using DataAbstractions.Dapper;
using Microsoft.Data.SqlClient;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Infrastructure.DbProvider
{
    public class DbProvider(string connectionString) : IDbProvider
    {
        private readonly string _connectionString = connectionString;

        public IDataAccessor GetConnectionString() 
            => new DataAccessor(new SqlConnection(_connectionString));
    }
}
