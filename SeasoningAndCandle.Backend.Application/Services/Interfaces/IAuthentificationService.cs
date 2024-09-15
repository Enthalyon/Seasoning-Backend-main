using SeasoningAndCandle.Backend.Domain.Entities;
using System.Security.Claims;

namespace SeasoningAndCandle.Backend.Application.Services.Interfaces
{
    public interface IAuthentificationService
    {
        (string, DateTime) GenerateToken(User user);
        ClaimsPrincipal ValidateToken(string token);
    }
}
