using Mapster;
using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Application.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler <GetCategoriesQuery, CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryViewModel> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            Category categories = await _categoryRepository.GetCategoriesAsync();
            return categories.Adapt<CategoryViewModel>();
        }
    }
}
