using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBuck.Models.OA
{
    public class OATemplateList : AbstractResp
    {
        [JsonProperty("template_list")]
        public List<MPTemplate> Templates { get; set; }
    }

    public class MPTemplate
    {
        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("primary_industry")]
        public string PrimaryIndustry { get; set; }

        [JsonProperty("deputy_industry")]
        public string DeputyIndustry { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }
    }
}