using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class JsSignature
    {
        [JsonProperty("noncestr")]
        public string NonceString { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}