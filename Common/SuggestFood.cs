using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIPFoodLookup.Common
{
    public class SuggestFood
    {
        [JsonProperty("inputText")]
        public string InputText { get; set; }

        [JsonProperty("allowed")]
        public bool Allowed { get; set; }
    }
}
