using Odds.Application.Features;
using Odds.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Application.ViewModels
{
    public class SelectionVm : BaseViewModel<Selection>
    {
        
        public Guid MarketGuid { get; set; }
        public decimal Odds { get; set; }
        public int Index { get; set; }
        public string Label { get; set; }
        public string Status { get; set; }
        public string MarketLabel { get; set; }
        public DateTime? DeadLine { get; set; }
        public SelectionVm(Selection selection):base(selection)
        {
            MarketGuid = selection.MarketGuid;
            Odds = selection.Odds;
            Index = selection.Index;
            Label = selection.ParticipantLabel;
            Status = selection.SelectionStatus.Name;
            MarketLabel = selection.Market?.Label;
            DeadLine = selection.Market?.EndDateTime;
        }
    }
}
