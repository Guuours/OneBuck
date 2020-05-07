using Newtonsoft.Json;

namespace OneBuck.Models.OA
{
    public class OAJsTicket : AbstractResp
    {
        public string Ticket { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}