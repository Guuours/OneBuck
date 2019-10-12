using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBuck.Models.MP
{
    public class MPUserList : AbstractResp
    {
        public int Total { get; set; }

        public int Count { get; set; }

        public UserListData Data { get; set; }
    }

    public class UserListData
    {
        public List<string> OpenId { get; set; }

        [JsonProperty("next_openid")]
        public string NextOpenId { get; set; }
    }
}