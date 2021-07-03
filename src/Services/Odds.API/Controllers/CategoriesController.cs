using MediatR;
using Microsoft.AspNetCore.Mvc;
using Odds.Application.Features.Category.Query;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet(Name = "GetAllCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoryVm>>> GetOrdersByUserName()
        {
            var query = new GetCategoryListQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }


    }
}
