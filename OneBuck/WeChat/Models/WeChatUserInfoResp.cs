namespace OneBuck.WeChat.Models
{
    public enum Gender
    {
        Male = 1,
        Femail = 2
    }

    public class WeChatUserInfoResp : AbstractResp
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