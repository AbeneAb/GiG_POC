using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using EventBus.Messages.Events;
using Microsoft.Extensions.Logging;
using Selection.Client.Contracts;
using ConsoleTables;

namespace Selection.Client.EventConsumer
{
    class SelectionDeletedEventConsumer : IConsumer<SelectionDeletedEvent>
    {
        public SelectionDeletedEventConsumer()
        {

        }
        private readonly ILogger<SelectionCreatedEventConsumer> _logger;
        private readonly ISelectionService _selectionService;
        //public SelectionDeletedEventConsumer(ILogger<SelectionCreatedEventConsumer> logger,ISelectionService service)
        //{
        //    _logger = logger;
        //    _selectionService = service;
        //}
        public async Task Consume(ConsumeContext<SelectionDeletedEvent> context)
        {
            var response = await _selectionService.GetSelections();
            var groupByMarket = response.GroupBy(x => x.MarketGuid);
            var table = new ConsoleTable("Index", "Label", "Odds", "Deadline", "Status");

            foreach (var marketGroup in groupByMarket)
            {
                string str = marketGroup.FirstOrDefault().MarketLabel;
                table.AddRow("", "", str, "", "");
                foreach (var selection in marketGroup)
                {
                    table.AddRow(selection.Index, selection.Label, selection.Odds, selection.DeadLine, selection.Status);
                }
                table.Write();
            }


        }
    }
}
