using MediatR;
using Odds.Application.ViewModels;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Events.Query
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery,List<EventsVm>>
    {
        private readonly IEventRepository _eventRepository;
        public GetEventListQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<EventsVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventRepository.GetAllEvent();
            return events.Select(e => new EventsVm(e)).ToList();
        }
    }
}
