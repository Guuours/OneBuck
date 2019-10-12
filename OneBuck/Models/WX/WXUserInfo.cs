namespace OneBuck.Models.WX
{
    public class WXUserInfo : AbstractResp
    {
        public string OpenId { get; set; }

        public string NickName { get; set; }

        public Gender Sex { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public string HeadImgUrl { get; set; }

        public string[] Privilege { get; set; }

        public string UnionId { get; set; }
    }
}