using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasking.Management.Application.Commands.CreateUser;
using Tasking.Management.Application.Commands.UpdateUserAddress;
using Tasking.Management.Domain.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Tasking.Management.CrossCutting.ProblemDetail.ErrorGenerator;

namespace Tasking.Management.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAcessor;
        public UsersController(IMediator mediator, IHttpContextAccessor contextAcessor)
        {
            _contextAcessor = contextAcessor;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateUserCommand), Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

                return Created(nameof(GetById), response);
            }
            catch (UserAlreadyExistException ex)
            {
                return Conflict(GetProblemDetails(ex, 409));
            }
        }

        [HttpPut("address/{userId}")]
        [Authorize(Roles = "user")]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), Status409Conflict)]
        public async Task<IActionResult> UpdateById([FromBody] UpdateUserAddressCommand command, Guid userId)
        {
            try
            {
                command.UserId = userId;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (UserNotExistException ex)
            {
                return Conflict(GetProblemDetails(ex,409));
            }

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            return Ok();
        }
    }
}
