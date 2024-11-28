using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Application.Queries
{
    public class GetCategoryByCodeQuery : IRequest<CategoryViewModel>
    {
        public Guid Code { get; set; }
    }
}
