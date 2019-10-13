using OneBuck.Models;
using OneBuck.Models.WX;

namespace OneBuck
{
    public class WX : Invoker
    {
        public static WXAccessToken GetAccessToken(string code, string appId, string appSecret)
        {
            var url = $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={appId}&secret={appSecret}&code={code}&grant_type=authorization_code";

            return RequestFor<WXAccessToken>(url);
        }

        public static WXAccessToken RefreshAccessToken(string refreshToken, string appId)
        {
            var url = $"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={appId}&grant_type=refresh_token&refresh_token={refreshToken}";

            return RequestFor<WXAccessToken>(url);
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

        public static WXUserInfo GetUserInfo(string accessToken, string openId)
        {
            var url = $"https://api.weixin.qq.com/sns/userinfo?access_token={accessToken}&openid={openId}";

            return RequestFor<WXUserInfo>(url);
        }
    }
}
