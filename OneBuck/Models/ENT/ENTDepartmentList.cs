using Newtonsoft.Json;
using System.Collections.Generic;

namespace OneBuck.Models.ENT
{
    public class ENTDepartmentList : AbstractResp
    {
        [JsonProperty("department")]
        public List<ENTDepartment> Departments { get; set; }
    }

    public class ENTDepartment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public int Order { get; set; }
    }
}