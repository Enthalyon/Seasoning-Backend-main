using Mapster;
using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Application.Queries
{
    public class GetCategoryByCodeQueryHandler : IRequestHandler<GetCategoryByCodeQuery, CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByCodeQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryViewModel> Handle(GetCategoryByCodeQuery request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetCategoryByCodeAsync(request.Code);
            return category.Adapt<CategoryViewModel>();
        }
    }
}
