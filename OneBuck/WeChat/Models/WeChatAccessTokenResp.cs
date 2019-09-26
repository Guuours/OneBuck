using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class WeChatAccessTokenResp : AbstractResp
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        public string OpenId { get; set; }

        public string Scope { get; set; }

        public string UnionId { get; set; }
    }
}