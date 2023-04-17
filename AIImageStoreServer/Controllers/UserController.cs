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

        [HttpPost]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] string username)
        {
            var user = await _userService.GetUserAsync(username);

            if (user != null)
                return Ok(user);
            return BadRequest();
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser userDetails)
        {
            var createUser = await _userService.CreateUser(userDetails);

            if(createUser != null)
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if(userLogin.Email == null && userLogin.Username == null)
                return BadRequest("Username or Email is Required");

            var userLoggedIn = await _userService.Login(userLogin);

            if (userLoggedIn != null)
                return Ok(userLoggedIn);
            return BadRequest();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout([FromBody] UserLogin userLogin)
        {
            if (userLogin.Username == null)
                return BadRequest("Username is Required");

            var userLoggedIn = await _userService.Logout(userLogin.Username);

            if (userLoggedIn != null)
                return Ok(userLoggedIn);
            return BadRequest();
        }

    }
}
