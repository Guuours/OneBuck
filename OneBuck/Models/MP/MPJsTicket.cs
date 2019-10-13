using Newtonsoft.Json;

namespace OneBuck.Models.MP
{
    public class MPJsTicket : AbstractResp
    {
        public string Ticket { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}