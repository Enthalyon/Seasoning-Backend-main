using SeasoningAndCandle.Backend.Domain.Entities;

namespace SeasoningAndCandle.Backend.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> RegisterUserAsync(User userModel);
    }
}
