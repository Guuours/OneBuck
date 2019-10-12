using Newtonsoft.Json;

namespace OneBuck.Models.MP
{
    public class MPSessionKey : AbstractResp
    {
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        public string OpenId { get; set; }
    }
}