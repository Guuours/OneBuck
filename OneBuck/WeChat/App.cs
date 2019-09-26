using OneBuck.WeChat.Models;

namespace OneBuck.WeChat
{
    public class App : Invoker
    {
        public static WeChatAccessTokenResp GetAccessToken(string code, string appId, string appSecret)
        {
            var url = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={appId}&secret={appSecret}&code={code}&grant_type=authorization_code";

            return RequestFor<WeChatAccessTokenResp>(url);
        }

        public static WeChatAccessTokenResp RefreshAccessToken(string refreshToken, string appId)
        {
            var url = $"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={appId}&grant_type=refresh_token&refresh_token={refreshToken}";

            return RequestFor<WeChatAccessTokenResp>(url);
        }

        public static bool VerifyAccessToken(string accessToken, string openId)
        {
            var url = $"https://api.weixin.qq.com/sns/auth?access_token={accessToken}&openid={openId}";

            var ret = RequestFor<PlainResp>(url);
            if (ret.ErrorCode == 0)
            {
                return true;
            }

            return false;
        }

        public static WeChatUserInfoResp GetUserInfo(string accessToken, string openId)
        {
            var url = $"https://api.weixin.qq.com/sns/userinfo?access_token={accessToken}&openid={openId}";

            return RequestFor<WeChatUserInfoResp>(url);
        }
    }
}