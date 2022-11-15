using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasking.Management.Application.Commands.CreateUser;
using Tasking.Management.Application.Commands.UpdateUserAddress;

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
            var response = await _mediator.Send(command);

            return Created(nameof(GetById), response);
        }

        [HttpPut("address/{userId}")]
        public async Task<IActionResult> UpdateById([FromBody] UpdateUserAddressCommand command, Guid userId)
        {
            command.UserId = userId;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            return Ok();
        }
    }
}
