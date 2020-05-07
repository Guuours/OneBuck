using Newtonsoft.Json;

namespace OneBuck.Models.OA
{
    public class OAAccessToken : AbstractResp
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}