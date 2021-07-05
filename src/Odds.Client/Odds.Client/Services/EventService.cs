using Odds.Client.Contracts;
using Odds.Client.Extensions;
using Odds.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Odds.Client.Services
{
    public class EventService : IEventService
    {
        private readonly HttpClient _client;
        public EventService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            var result = await _client.GetAsync($"/api/v1/Event");
            return await result.ReadContentAs<IEnumerable<EventModel>>();
        }
    }
}
