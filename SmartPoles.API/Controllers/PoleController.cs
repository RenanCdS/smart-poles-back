using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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

        [HttpDelete("{poleId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeletePole(Guid poleId)
        {
            var deletePoleRequest = new DeletePoleRequest(poleId);
            var response = await _mediator.Send(deletePoleRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePole(UpdatePoleRequest updatePoleRequest)
        {
            var response = await _mediator.Send(updatePoleRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }
            return Ok();
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
