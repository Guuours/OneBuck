using Newtonsoft.Json;

namespace OneBuck.Models.OA
{
    public class OAMessageResult : AbstractResp
    {
        [JsonProperty("msgid")]
        public string MessageId { get; set; }
    }
}