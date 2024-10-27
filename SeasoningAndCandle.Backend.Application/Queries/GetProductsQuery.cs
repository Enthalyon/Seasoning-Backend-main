using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductsCategoryViewModel>>
    {
        public int? Limit { get; set; }
    }
}
