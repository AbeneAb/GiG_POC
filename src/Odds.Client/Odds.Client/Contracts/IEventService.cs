﻿using Odds.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Odds.Client.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventModel>> GetEvents();
    }
}
