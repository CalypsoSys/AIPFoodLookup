#define DEBUG_LOCAL
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
#if DEBUG_LOCAL
        private const string _apiScheme = "http";
        private const string _apiHost = "localhost";
        //private const string _apiHost = "10.0.2.2";
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

        private UriBuilder GetBaseUrl(string path)
        {
            UriBuilder builder = new UriBuilder();
            builder.Scheme = _apiScheme;
            builder.Host = _apiHost;
#if DEBUG_LOCAL
            builder.Port = _apiPort;
#endif
            builder.Path = path;
            return builder;

        }

        public async Task<Result> Search(string search)
        {
            try
            {
                UriBuilder builder = GetBaseUrl("/search");
                builder.Query = string.Format("key={0}", search);

                var response = await _httpClient.GetAsync(builder.Uri);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Result>(jsonString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> Suggest(string suggestion, bool allowed )
        {
            try
            {
                var json = JsonConvert.SerializeObject(new SuggestFood() { InputText = suggestion, Allowed = allowed });
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                UriBuilder builder = GetBaseUrl("/suggest");

                return await _httpClient.PostAsync(builder.Uri, content);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Result> Categories(string search)
        {
            try
            {
                UriBuilder builder = GetBaseUrl("/categories");

                var response = await _httpClient.GetAsync(builder.Uri);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Result>(jsonString);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
