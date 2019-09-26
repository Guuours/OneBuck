using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBuck.WeChat.Models
{
    public class MPServerAddressResp : AbstractResp
    {
        [JsonProperty("ip_list")]
        public List<string> IPList { get; set; }
    }
}