using Microsoft.AspNetCore.Mvc;

namespace Task.Management.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string userId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetbyId(string userId)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
