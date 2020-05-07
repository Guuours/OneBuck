using OneBuck.Models.MP;

namespace OneBuck
{
    public class MP : Invoker
    {
        public static MPSessionKey GetSessionKey(string code, string appId, string secret)
        {
            var reqUrl = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={code}&grant_type=authorization_code";

            return RequestFor<MPSessionKey>(reqUrl);
        }
    }
}