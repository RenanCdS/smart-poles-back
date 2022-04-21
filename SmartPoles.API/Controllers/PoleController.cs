using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.Application.Requests.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartPoles.API.Controllers
{
    [ApiController]
    [Route("pole")]
    public class PoleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> AddPole(AddPoleRequest addPoleRequest)
        {
            var response = await _mediator.Send(addPoleRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllPoles()
        {
            var getAllPolesQuery = new GetAllPolesQuery();
            var response = await _mediator.Send(getAllPolesQuery);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok(response.Value);
        }

        [HttpGet("{condominiumId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetPoleByCondominiumId(Guid condominiumId)
        {
            var getPolesByCondominiumId = new GetPolesByCondominiumIdQuery(condominiumId);
            var response = await _mediator.Send(getPolesByCondominiumId);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok(response.Value);
        }
    }
}
