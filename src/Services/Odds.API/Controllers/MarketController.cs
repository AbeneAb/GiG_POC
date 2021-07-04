using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Net;
using Odds.Application.Features.Market.Command;
using Odds.Application.ViewModels;
using Odds.Application.Features.Market.Query;

namespace Odds.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarketController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MarketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name = "CreateMarket")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateMarket([FromBody] CreateMarketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet(Name = "GetMarket")]
        [ProducesResponseType(typeof(IEnumerable<MarketVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MarketVm>>> GetMarkets()
        {
            var query = new GetMarketListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpPut(Name = "UpdateMarket")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateMarket([FromBody] UpdateMarketCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteMarket")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteMarket(Guid id)
        {
            var command = new DeleteMarketCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
