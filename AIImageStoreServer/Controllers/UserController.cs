using AIImageStoreServer.Models;
using AIImageStoreServer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIImageStoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpPost]
        [Route("/GetUser")]
        public async Task<IActionResult> GetUser([FromBody] string username)
        {
            var user = await _userService.GetUserAsync(username);

            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        // Post: api/<UserController>
        [HttpPost]
        [Route("/CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser userDetails)
        {
            var createUser = await _userService.CreateUser(userDetails);

            if(createUser != null)
                return Ok();
            return BadRequest();
        }
    }
}
