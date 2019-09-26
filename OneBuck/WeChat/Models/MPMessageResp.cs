using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class MPMessageResp : AbstractResp
    {
        [JsonProperty("msgid")]
        public string MessageId { get; set; }
    }
}