using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.Application.Requests.Queries;
using SmartPoles.Domain.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPoles.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AuthenticationController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var authenticateRequest = _mapper.Map<AuthenticateRequest>(userDto);

            var authenticateResponse = await _mediator.Send(authenticateRequest);

            if (!authenticateResponse.IsSuccess)
            {
                return BadRequest(authenticateResponse.ErrorMessages.FirstOrDefault());
            }
            return Ok(authenticateResponse.Value);
        }

        [HttpPost("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> Register(RegisterUserRequest registerRequest)
        {
            var response = await _mediator.Send(registerRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAllUsersQuery = new GetAllUsersQuery();
            var response = await _mediator.Send(getAllUsersQuery);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok(response.Value);
        }


        [HttpGet("user/{username:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
            var response = await _mediator.Send(getUserByUsernameQuery);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok(response.Value);
        }

        [HttpDelete("user/{username:string}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var deleteUserRequest = new DeleteUserRequest(username);
            var response = await _mediator.Send(deleteUserRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok(response.Value);
        }
    }
}
