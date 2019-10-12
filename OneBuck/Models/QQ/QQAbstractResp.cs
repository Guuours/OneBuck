using Newtonsoft.Json;

namespace OneBuck.Models.QQ
{
    public abstract class QQAbstractResp
    {
        [JsonProperty("ret")]
        public int ErrorCode { get; set; }

        [JsonProperty("msg")]
        public string ErrorMessage { get; set; }
    }
}