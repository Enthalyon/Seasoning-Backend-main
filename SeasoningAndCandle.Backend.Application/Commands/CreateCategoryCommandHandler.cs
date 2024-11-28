using Mapster;
using MediatR;
using SeasoningAndCandle.Backend.Application.ViewModels;
using SeasoningAndCandle.Backend.Domain.Entities;
using SeasoningAndCandle.Backend.Domain.Interfaces;

namespace SeasoningAndCandle.Backend.Application.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CategoryViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //TODO: Hacer validaciones

            Category createdCategory = await _categoryRepository.CreateCategoryAsync(request.Adapt<Category>());

            return createdCategory.Adapt<CategoryViewModel>();
        }
    }
}
