using Mapster;
using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;
using SeasoningAndCandle.Backend.Domain.Aggregates;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Application.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsCategoryViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductsCategoryViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            List<ProductsCategory> result = await _productRepository.GetProductsAsync(request.Limit ?? 10);

            return result.Adapt<List<ProductsCategoryViewModel>>();
        }
    }
}
