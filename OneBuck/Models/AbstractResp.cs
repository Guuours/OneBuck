using Newtonsoft.Json;

namespace OneBuck.Models
{
    public enum Gender
    {
        Unknown,
        Male,
        Femail
    }

    public abstract class AbstractResp
    {
        [JsonProperty("errcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrorMessage { get; set; }
    }
}