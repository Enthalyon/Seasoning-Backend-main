using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeasoningAndCandle.Backend.Application.Queries;
using SeasoningAndCandle.Backend.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeasoningAndCandle.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] GetProductsQuery getProductsQuery)
        {
            List<ProductsCategoryViewModel> result = await _mediator.Send(getProductsQuery);

            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
