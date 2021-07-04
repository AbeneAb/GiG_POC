using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection.Client.Models
{
    public class SelectionModel
    {
        public Guid Id { get; set; }
        public Guid MarketGuid { get; set; }
        public decimal Odds { get; set; }
        public int Index { get; set; }
        public string Label { get; set; }
        public string Status { get; set; }
        public string MarketLabel { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
