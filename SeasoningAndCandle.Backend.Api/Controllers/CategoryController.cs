using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeasoningAndCandle.Backend.Application.Commands;
using SeasoningAndCandle.Backend.Application.Queries;
using SeasoningAndCandle.Backend.Application.ViewModels;

namespace SeasoningAndCandle.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CategoryViewModel result = await _mediator.Send(createCategoryCommand);
            return Ok(result);
        }

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync([FromQuery] GetCategoriesQuery getCategoriesQuery)
        {
            CategoryViewModel result = await _mediator.Send(getCategoriesQuery);
            return Ok(result);
        }

        //GET: api/category/5
        [HttpGet("{code}")]
        public async Task<IActionResult> GetCategoryByCodeAsync(Guid code) 
        {
            CategoryViewModel result = await _mediator.Send(new GetCategoryByCodeQuery { Code = code });
            return Ok(result);
        }

    }
}
