using Newtonsoft.Json;

namespace OneBuck.Models.MP
{
    public class MPMessageResult : AbstractResp
    {
        [JsonProperty("msgid")]
        public string MessageId { get; set; }
    }
}