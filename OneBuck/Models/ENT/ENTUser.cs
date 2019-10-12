using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBuck.Models.ENT
{
    public enum ENTUserStatus
    {
        Activated = 1,
        Forbidden = 2,
        Inactivated = 4
    }

    public class ENTUser : AbstractResp
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public List<int> Department { get; set; }

        public List<int> Order { get; set; }

        public string Position { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        [JsonProperty("is_leader_in_dept")]
        public List<int> IsLeader { get; set; }

        public string Avatar { get; set; }

        public string Telephone { get; set; }

        public bool Enable { get; set; }

        public string Alias { get; set; }

        [JsonProperty("extattr")]
        public ExtAttribute ExtAttribute { get; set; }

        public ENTUserStatus Status { get; set; }

        [JsonProperty("qr_code")]
        public string QRCode { get; set; }

        [JsonProperty("external_profile")]
        public ExternalProfile ExternalProfile { get; set; }

        public string Address { get; set; }
    }

    public class ExtAttribute
    {
        [JsonProperty("attrs")]
        public List<ExternalAttribute> Attributes { get; set; }
    }

    public class ExternalProfile
    {
        [JsonProperty("external_corp_name")]
        public string ExternalCorpName { get; set; }

        [JsonProperty("external_attr")]
        public List<ExtAttribute> ExternalAttributes { get; set; }
    }

    public enum ExternalAttributeType
    {
        Text,
        Web,
        MP
    }

    public class ExternalAttribute
    {
        public ExternalAttributeType Type { get; set; }

        public string Name { get; set; }

        public ExternalAttributeText Text { get; set; }

        public ExternalAttributeWeb Web { get; set; }

        public ExternalAttributeMP MP { get; set; }
    }

    public class ExternalAttributeText
    {
        public string Value { get; set; }
    }

    public class ExternalAttributeWeb
    {
        public string Url { get; set; }

        public string Title { get; set; }
    }

    public class ExternalAttributeMP
    {
        public string AppId { get; set; }

        public string PagePath { get; set; }

        public string Title { get; set; }
    }
}