using Lab_8.Model;
using Lab_8.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Linq;

namespace Lab_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequest request)
        {
            var response = userService.Authenticate(request);
            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetAll()
        {
            return Ok(userService.GetUsers());
        }

        [HttpGet("count")]
        [Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetCount()
        {
            return Ok(new { count = userService.GetUsers().Count() });
        }
    }
}