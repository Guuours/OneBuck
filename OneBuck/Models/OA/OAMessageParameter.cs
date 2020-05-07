using Newtonsoft.Json;

namespace OneBuck.Models.OA
{
    public class OAMessageParameter
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        public OAMessageParameter(string value, string color = null)
        {
            Value = value;
            Color = color;
        }
    }
}