using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasking.Management.Application.Commands.CreateUser;

namespace Tasking.Management.API.Controllers
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
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            //TODO Create InputValidation
            var id = await _mediator.Send(command);

            //TODO Create ViewModel to this response
            var response = new { Id = id, Email = command.Email, Name = command.Name };

            return Created(nameof(GetById), response);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            return Ok();
        }
    }
}
