﻿using Odds.Domain.Exceptions;
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
        private Guid _marketGuid;
        public Guid MarketGuid => _marketGuid;
        private int _selectionStatusStatusId;
        public int SelectionStatusId => _selectionStatusStatusId;
        public MarketStatus SelectionStatus { get; private set; }

        public virtual Market Market { get; private set; }

        private decimal _odds;
        public decimal Odds => _odds;
        private int _index;
        public int Index => _index;
        private string _participantLabel;
        public string ParticipantLabel => _participantLabel;

        protected Selection() 
        {

        }
        public Selection(decimal odds, int index, string label,int selectionStatusStatusId)
        {
            if(odds<= 0)
                throw new DomainException($"Odd cannot be less than zero");
            _odds = odds;
            _index = index;
            _participantLabel = label;
            _selectionStatusStatusId = selectionStatusStatusId;
        }
        public Selection(Guid marketGuid, decimal odds, int index, string label, int selectionStatusStatusId) : this(odds, index, label, selectionStatusStatusId) 
        {
            _marketGuid = marketGuid;
        }
        public void UpdateSelection(Guid marketGuid, decimal odds, int index, string label, int selectionStatusStatusId) 
        {
            _odds = odds;
            _index = index;
            _participantLabel = label;
            _selectionStatusStatusId = selectionStatusStatusId;
            _marketGuid = marketGuid;
        }
    }
}
