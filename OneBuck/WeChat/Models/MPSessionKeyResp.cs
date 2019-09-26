using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class MPSessionKeyResp : AbstractResp
    {
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        public string OpenId { get; set; }
    }
}