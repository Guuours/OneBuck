using OneBuck.Models.WX;
using System.Collections.Generic;

namespace OneBuck.Models.OA
{
    public class OAUserInfo : AbstractResp
    {
        public int Subscribe { get; set; }

        public string OpenId { get; set; }

        public string NickName { get; set; }

        public Gender Sex { get; set; }

        public string Language { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string HeadImgUrl { get; set; }

        public long Subscribe_Time { get; set; }

        public string UnionId { get; set; }

        public string Remark { get; set; }

        public int GroupId { get; set; }

        public List<int> TagId_List { get; set; }

        public string Subscribe_Scene { get; set; }

        public string QR_Scene { get; set; }

        public string QR_Scene_Str { get; set; }
    }
}