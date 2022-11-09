using Microsoft.AspNetCore.Mvc;

namespace Task.Management.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetbyId(string userId)
        {
            return Ok();
        }
    }
}
