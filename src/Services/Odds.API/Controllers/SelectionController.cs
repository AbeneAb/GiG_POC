using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
