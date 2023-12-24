using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIPFoodLookup.Common
{
    public class SearchResult
    {
        [JsonProperty("allowed")]
        public List<string> Allowed {  get; set; }
        [JsonProperty("not_allowed")]
        public List<string> NotAllowed { get; set; }
    }
}
