using Newtonsoft.Json;

namespace OneBuck.WeChat.Models
{
    public class MPMessageParameter
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        public MPMessageParameter(string value, string color = null)
        {
            Value = value;
            Color = color;
        }
    }
}