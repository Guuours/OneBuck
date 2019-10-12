using Newtonsoft.Json;
using OneBuck.Models;
using System.Collections.Generic;

namespace OneBuck.Models.MP
{
    public class MPServerAddress : AbstractResp
    {
        [JsonProperty("ip_list")]
        public List<string> IPList { get; set; }
    }
}