using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Application.Commands
{
    public class LoginCommand : IRequest<TokenViewModel>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
