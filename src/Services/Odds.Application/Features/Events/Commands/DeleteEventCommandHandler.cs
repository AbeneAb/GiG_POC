using MediatR;
using Odds.Domain.Entities;
using Odds.Domain.Exceptions;
using Odds.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Events.Commands
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public DeleteEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            if(@event == null) 
            {
                throw new NotFoundException(nameof(Event),request.Id);
            }
            await _eventRepository.DeleteAsync(@event);
            return Unit.Value;
        }
    }
}
