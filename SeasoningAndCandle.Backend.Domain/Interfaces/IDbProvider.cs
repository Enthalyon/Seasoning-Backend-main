using DataAbstractions.Dapper;

namespace SeasoningAndCandle.Backend.Domain.Interfaces
{
    public interface IDbProvider
    {
        IDataAccessor GetConnectionString();
    }
}
