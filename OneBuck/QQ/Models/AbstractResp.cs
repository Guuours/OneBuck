using Newtonsoft.Json;

namespace OneBuck.QQ.Models
{
    public abstract class AbstractResp
    {
        [JsonProperty("ret")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string ErrorMessage { get; set; }
    }
}