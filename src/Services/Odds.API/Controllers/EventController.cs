using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odds.Application.Features.Events.Commands;
using Odds.Application.Features.Events.Query;
using Odds.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Odds.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "CreateEvent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEvent([FromBody] CreateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet(Name = "GetEvents")]
        [ProducesResponseType(typeof(IEnumerable<EventsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EventsVm>>> GetEvents()
        {
            var query = new GetEventListQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEvent([FromBody] UpdateEventCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteEvent(Guid id)
        {
            var command = new DeleteEventCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
