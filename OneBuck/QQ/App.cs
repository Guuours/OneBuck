using Newtonsoft.Json;
using OneBuck.QQ.Models;
using System;
using System.Net;
using System.Text;

namespace OneBuck.QQ
{
    public abstract class App
    {
        protected static T RequestFor<T>(string url) where T : AbstractResp
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                // call qq api
                var json = string.Empty;
                try
                {
                    json = client.DownloadString(url);
                }
                catch (Exception ex)
                {
                    throw new OneBuckException("Error communicating with remote server", ex);
                }

                // deserialization
                T ret;
                try
                {
                    ret = JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    throw new OneBuckException("Error deserializing response", ex);
                }
                
                if (ret.ErrorCode != 0)
                {
                    throw new OneBuckException(ret.ErrorCode.ToString(), ret.ErrorMessage);
                }

                return ret;
            }
        }

        public static QQUserInfo GetUserInfo(string accessToken, string consumerKey, string openId)
        {
            var url = $"https://graph.qq.com/user/get_user_info?access_token={accessToken}&oauth_consumer_key={consumerKey}&openid={openId}&format=json";

            return RequestFor<QQUserInfo>(url);
        }
    }
}