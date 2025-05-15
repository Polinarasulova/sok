using Microsoft.AspNetCore.Mvc;

namespace LemonApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}")]
        public IActionResult Login(string username)
        {
            var user = _userService.GetUser(username);
            return Ok(user);
        }
    }
}