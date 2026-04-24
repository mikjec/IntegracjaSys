using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "number", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetRandomPrime()
        {
            int[] numbers = { 2, 3, 5, 7, 11, 13 };
            Random rand = new Random();
            return Ok(new { number = numbers[rand.Next(numbers.Length)] });
        }
    }
}