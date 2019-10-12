using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBuck.Models.ENT
{
    public class ENTUserSimpleList : AbstractResp
    {
        public List<ENTSimpleUser> UserList { get; set; }
    }

    public class ENTSimpleUser
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        [JsonProperty("department")]
        public List<int> Departments { get; set; }
    }
}