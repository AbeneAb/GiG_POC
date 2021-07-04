using Selection.Client.Contracts;
using Selection.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Selection.Client.Services
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
