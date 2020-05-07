using Newtonsoft.Json;
using OneBuck.Models;
using System.Collections.Generic;

namespace OneBuck.Models.OA
{
    public class OAServerAddress : AbstractResp
    {
        [JsonProperty("ip_list")]
        public List<string> IPList { get; set; }
    }
}