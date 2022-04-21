using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartPoles.Application.Requests;
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
    }
}
