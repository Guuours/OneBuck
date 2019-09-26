using OneBuck.WeChat.Models;

namespace OneBuck.WeChat
{
    public class Enterprise : Invoker
    {
        public static MPAccessTokenResp GetAccessToken(string corpId, string corpSecret)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={corpId}&corpsecret={corpSecret}";

            return RequestFor<MPAccessTokenResp>(url);
        }
    }
}