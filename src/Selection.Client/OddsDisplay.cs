using ConsoleTables;
using Microsoft.Extensions.Logging;
using Selection.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection.Client
{
    public class OddsDisplay
    {
        private readonly ISelectionService _selectionService;
        private readonly ILogger<OddsDisplay> _logger;
        public OddsDisplay(ISelectionService service,ILogger<OddsDisplay> logger)
        {
            _selectionService = service;
            _logger = logger;
        }
        public async Task<IEnumerable<Models.SelectionModel>> Run()
        {
            var response = await _selectionService.GetSelections();
            var groupByMarket = response.GroupBy(x => x.MarketGuid);
            var table = new ConsoleTable("Index", "Label" ,"Odds" ,"Deadline" ,"Status");
          
            foreach (var marketGroup in groupByMarket) 
            {
                string str = marketGroup.FirstOrDefault().MarketLabel;
                table.AddRow("","",str,"","");
                foreach(var selection in marketGroup) 
                {
                    table.AddRow(selection.Index, selection.Label,selection.Odds,selection.DeadLine,selection.Status);
                }
                table.Write();
            }
            

            return response;

        }

    }
}
