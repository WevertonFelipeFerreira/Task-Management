using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Management.Application.Commands.CreateUser;

namespace Task.Management.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
        {
            var id = await _mediator.Send(createUserCommand);
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetbyId(string userId)
        {
            return Ok();
        }
    }
}
