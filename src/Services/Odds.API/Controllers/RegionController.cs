using MediatR;
using Microsoft.AspNetCore.Mvc;
using Odds.Application.Features.Region.Command;
using Odds.Application.Features.Region.Query;
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
    public class RegionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllRegion")]
        [ProducesResponseType(typeof(IEnumerable<RegionVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<RegionVm>>> GetAllRegion()
        {
            var query = new GetRegionListQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
        [HttpPost(Name ="CreateRegion")]
        [ProducesResponseType(typeof(Guid),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateRegion([FromBody] CreateRegionCommand command) 
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
