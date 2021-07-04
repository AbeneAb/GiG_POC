using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using EventBus.Messages.Events;
using Microsoft.Extensions.Logging;

namespace Selection.Client.EventConsumer
{
    public class SelectionCreatedEventConsumer : IConsumer<SelectionCreatedEvent>
    {
        public SelectionCreatedEventConsumer()
        {

        }
        private readonly ILogger<SelectionCreatedEventConsumer> _logger;
        //public SelectionCreatedEventConsumer(ILogger<SelectionCreatedEventConsumer> logger)
        //{
        //    _logger = logger;
        //}
      

        public async Task Consume(ConsumeContext<SelectionCreatedEvent> context)
        {
            var command = context.Message;
            _logger.LogInformation("SelectionCreatedEvent consumed successfully. Created Selection Id : {newOrderId}", command.Id);

            Console.Write(command.Label);
        }
    }
}
