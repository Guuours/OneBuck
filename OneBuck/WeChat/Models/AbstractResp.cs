using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public abstract class AbstractResp
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }
    }
}