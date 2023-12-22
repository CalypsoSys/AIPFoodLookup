using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPFoodLookup.Common
{
    internal class HashimoJoeApi
    {
#if DEBUGX
        private const string _apiScheme = "http";
        private const string _apiHost = "localhost";
        private const int _apiPort = 8080;
#else
        private const string _apiScheme = "https";
        private const string _apiHost = "api.hashimojoe.com";
#endif
        private readonly HttpClient _httpClient;

        public HashimoJoeApi()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<SearchResult> Search(string search)
        {
            try
            {
                UriBuilder builder = new UriBuilder();
                builder.Scheme = _apiScheme;
                builder.Host = _apiHost;
                builder.Path = "/search";
#if DEBUGX
                builder.Port = _apiPort;
#endif
                builder.Query = string.Format("key={0}", search);

                Uri url = builder.Uri;
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SearchResult>(jsonString);
            }
            catch (HttpRequestException e)
            {
                // Handle exception (e.g., log error, throw custom exception)
                throw;
            }
        }
    }
}
