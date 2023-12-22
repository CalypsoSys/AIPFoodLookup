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
        [JsonProperty("possible_allowed")]
        public List<string> PossibleAllowed {  get; set; }
        [JsonProperty("possible_disallowed")]
        public List<string> PossibleDisallowed { get; set; }
    }
}
