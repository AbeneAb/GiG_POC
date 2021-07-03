using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odds.Domain.Entities
{
    public class Selection : EntityBase
    {
        private readonly Guid _marketGuid;
        public Guid MarketGuid => _marketGuid;
        private readonly int _selectionStatusStatusId;
        public int SelectionStatusId => _selectionStatusStatusId;
        public MarketStatus SelectionStatus { get; private set; }

        public virtual Market Market { get; private set; }

        private readonly decimal _odds;
        public decimal Odds => _odds;
        private readonly int _index;
        public int Index => _index;
        private readonly string _participantLabel;
        public string ParticipantLabel => _participantLabel;

        protected Selection() 
        {

        }
        public Selection(decimal odds, int index, string label,int selectionStatusStatusId)
        {
            _odds = odds;
            _index = index;
            _participantLabel = label;
            _selectionStatusStatusId = selectionStatusStatusId;
        }
    }
}
