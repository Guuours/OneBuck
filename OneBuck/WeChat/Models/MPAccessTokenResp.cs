using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class MPAccessTokenResp : AbstractResp
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}