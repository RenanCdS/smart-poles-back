using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SmartPoles.Domain.DTOs.Requests;
using Microsoft.AspNetCore.Http;

namespace SmartPoles.API.Controllers
{
    [ApiController]
    [Route("condominium")]
    public class CondominiumController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CondominiumController()
        {

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> AddCondominium(AddCondominiumDto addCondominiumDto)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCondominium(UpdateCondominiumDto updateCondominiumDto)
        {
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteCondominium(Guid condominiumId)
        {
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<IActionResult> GetCondominiums()
        {
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
