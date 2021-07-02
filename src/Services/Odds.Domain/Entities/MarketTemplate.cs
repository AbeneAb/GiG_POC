using Odds.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Odds.Domain.Entities
{
    public class MarketTemplate : EntityBase
    {
        private readonly string _name;
        public string Name => _name;
        private readonly string _friendlyName;
        public string FriendlyName => _friendlyName;
        protected MarketTemplate() 
        {
        }
        public MarketTemplate(string name, string friendlyName): base() 
        {
            _name = name;
            _friendlyName = friendlyName;
        }

    }
}
