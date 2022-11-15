using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tasking.Management.Application.Commands.CreateUser;
using Tasking.Management.Application.Commands.UpdateUserAddress;
using Tasking.Management.Domain.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

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
        [ProducesResponseType(typeof(ProblemDetails),Status409Conflict)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);

                return Created(nameof(GetById), response);
            }
            catch (UserAlreadyExistException ex)
            {
                //TODO Create utils to generate problem detail
                var error = new ProblemDetails
                {
                    Type = "https://example.com",
                    Title = ex.Message,
                    Detail = "A user with the provided email already exists.",
                    Status = 409,
                    Instance = _contextAcessor.HttpContext!.Request.Path
                };

                return Conflict(error);
            }
        }

        [HttpPut("address/{userId}")]
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
                var error = new ProblemDetails
                {
                    Type = "https://example.com",
                    Title = ex.Message,
                    Detail = "It was not possible to update address for a user that does not exist.",
                    Status = 409,
                    Instance = _contextAcessor.HttpContext!.Request.Path
                };

                return Conflict(error);
            }

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(string userId)
        {
            return Ok();
        }
    }
}
