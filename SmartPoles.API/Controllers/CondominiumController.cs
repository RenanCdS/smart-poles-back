using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using SmartPoles.Application.Requests.Queries;
using SmartPoles.Application.Requests.Commands;

namespace SmartPoles.API.Controllers
{
    [ApiController]
    [Route("condominium")]
    public class CondominiumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CondominiumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> AddCondominium(AddCondominiumRequest addCondominiumRequest)
        {
            var response = await _mediator.Send(addCondominiumRequest);

            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages?.FirstOrDefault());
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCondominium(UpdateCondominiumRequest updateCondominiumRequest)
        {
            var response = await _mediator.Send(updateCondominiumRequest);
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessages.FirstOrDefault());
            }

            return Ok();
        }

        [HttpDelete("{condominiumId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteCondominium(Guid condominiumId)
        {
            var request = new DeleteCondominiumRequest()
            {
                Id = condominiumId
            };
            var response = await _mediator.Send(request);
            if (!response.IsSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetCondominiums()
        {
            var request = new GetAllCondominiumsQuery();
            var response = await _mediator.Send(request);

            return Ok(response.Value);
        }
    }
}
