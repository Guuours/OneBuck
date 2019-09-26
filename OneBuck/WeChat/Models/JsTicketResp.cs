using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class JsTicketResp : AbstractResp
    {
        public string Ticket { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}