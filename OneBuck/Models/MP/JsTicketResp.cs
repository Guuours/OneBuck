using Newtonsoft.Json;
using OneBuck.Models;

namespace OneBuck.Models.MP
{
    public class JsTicketResp : AbstractResp
    {
        public string Ticket { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}