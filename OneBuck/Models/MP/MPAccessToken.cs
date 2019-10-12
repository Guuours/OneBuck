using Newtonsoft.Json;
using OneBuck.Models;

namespace OneBuck.Models.MP
{
    public class MPAccessToken : AbstractResp
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}