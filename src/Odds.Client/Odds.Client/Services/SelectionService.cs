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
    public class SelectionService : ISelectionService
    {
        private readonly HttpClient _client;
        public SelectionService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<IEnumerable<SelectionModel>> GetSelections()
        {
            var result = await _client.GetAsync($"/api/v1/Selection");

            return await result.ReadContentAs<IEnumerable<SelectionModel>>();


        }
    }
}
