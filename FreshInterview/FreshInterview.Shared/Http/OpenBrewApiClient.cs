using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FreshInterview.Shared.Models;

namespace FreshInterview.Shared.Http
{
	public class OpenBrewApiClient
	{
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions JsonOptions => new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

        public OpenBrewApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://api.openbrewerydb.org/breweries");
		}

		public async Task<List<Brewery>> GetBreweries(int page = 1, int take = 20)
		{
			var request = await _httpClient.GetAsync($"?page={page}&per_page={take}");
            request.EnsureSuccessStatusCode();

			var rawResult = await request.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Brewery>>(rawResult, JsonOptions);
        }
    }
}

