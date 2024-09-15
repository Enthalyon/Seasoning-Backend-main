using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Application.Commands
{
    public class RegisterCommand : IRequest<TokenViewModel>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Phone { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
