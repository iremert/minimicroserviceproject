
using Microsoft.AspNetCore.Mvc;
using UserService.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserServicee _userService;

        public UsersController(UserServicee userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers() => Ok(_userService.GetAll());
    }
}
