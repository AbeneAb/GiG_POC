using MediatR;
using Microsoft.AspNetCore.Mvc;
using Odds.Application.Features.Selection.Command;
using Odds.Application.Features.Selection.Query;
using Odds.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using EventBus.Messages.Events;

namespace Odds.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SelectionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SelectionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "CreateSelection")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateSelection([FromBody] CreateSelectionCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet(Name ="GetSelections")]
        [ProducesResponseType(typeof(IEnumerable<SelectionVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<SelectionVm>>> GetSelections() 
        {
            var query = new GetSelectionListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut(Name = "UpdateSelection")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateSelection([FromBody] UpdateSelectionCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteSelection")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteSelection(Guid id)
        {
            var command = new DeleteSelectionCommand() { Id = id };
            await _mediator.Send(command);
            var eventMessage = new SelectionDeletedEvent(id, DateTime.UtcNow);
            return NoContent();
        }

    }
}
