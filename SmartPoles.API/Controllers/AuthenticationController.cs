using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPoles.Data;
using SmartPoles.Domain.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPoles.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly SmartPolesContext _context;
        public AuthenticationController(SmartPolesContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
