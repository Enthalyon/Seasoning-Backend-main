using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Application.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryViewModel>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
