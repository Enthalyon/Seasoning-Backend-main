using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeasoningAndCandle.Backend.Application.Commands;
using SeasoningAndCandle.Backend.Application.ViewModels;
using System.Net;

namespace SeasoningAndCandle.Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //* POST http://localhost:5000/api/auth/sign-in
        [HttpPost("sign-in")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand loginCommand)
        {
            TokenViewModel token = await _mediator.Send(loginCommand);
            return Ok(token);
        }

        //* POST http://localhost:5000/api/auth/sign-up
        [HttpPost("sign-up")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand registerCommand)
        {
            TokenViewModel token = await _mediator.Send(registerCommand);

            return StatusCode(HttpStatusCode.Created.GetHashCode(), token);
        }
    }
}
