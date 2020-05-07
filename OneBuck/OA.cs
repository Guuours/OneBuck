using Catalyzer.Conversion;
using Catalyzer.Cryptography;
using Catalyzer.Math;
using Newtonsoft.Json;
using OneBuck.Models.OA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OneBuck
{
    public class OA : Invoker
    {
        public static OAAccessToken GetAccessToken(string appId, string appSecret)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={appSecret}";

            return RequestFor<OAAccessToken>(reqUrl);
        }

        public static OAServerAddress GetServerAddress(string accessToken)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={accessToken}";

            return RequestFor<OAServerAddress>(reqUrl);
        }

        public static OAUserInfo GetUserInfo(string accessToken, string openId)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={accessToken}&openid={openId}&lang=zh_CN";

            return RequestFor<OAUserInfo>(reqUrl);
        }

        public static OAUserList GetUserList(string accessToken, string nextOpenId = null)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/user/get?access_token={accessToken}&next_openid={nextOpenId}";

            return RequestFor<OAUserList>(reqUrl);
        }

        public static OATemplateList GetTemplateList(string accessToken)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={accessToken}";

            return RequestFor<OATemplateList>(reqUrl);
        }

        public static OAMessageResult SendTemplateMessage(string accessToken, string openId, string templateId, Dictionary<string, OAMessageParameter> @params, string jumpUrl = null)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={accessToken}";

            var payload = new
            {
                touser = openId,
                template_id = templateId,
                data = @params,
                url = jumpUrl
            };

            return RequestFor<OAMessageResult>(reqUrl, payload);
        }

        public static OAJsTicket GetJsTicket(string accessToken)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";

            return RequestFor<OAJsTicket>(reqUrl);
        }

        public static OAJsSignature GetJsSignature(string ticket, string url)
        {
            var nonceString = Randomness.RandomText(16, RandomTextOption.All);
            var timestamp = DateTime.Now.ToUnixEpoch();
            var raw = $"jsapi_ticket={ticket}&noncestr={nonceString}&timestamp={timestamp}&url={url}";
            var signature = raw.SHA1().ToLower();

            return new OAJsSignature
            {
                NonceString = nonceString,
                TimeStamp = timestamp,
                Signature = signature
            };
        }

        public static bool VerifyData(string sessionKey, string signature, string data)
        {
            var raw = data + sessionKey;
            return signature == raw.SHA1();
        }

        public static OAUserInfo DecryptData(string sessionKey, string iv, string data)
        {
            string output = string.Empty;
            using (Aes aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = Encoding.UTF8.GetBytes(sessionKey.FromBase64());
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aes.CreateDecryptor();

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(data)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            output = sr.ReadToEnd();
                        }
                    }
                }
            }

            OAUserInfo userInfo;
            try
            {
                userInfo = JsonConvert.DeserializeObject<OAUserInfo>(output);
            }
            catch (Exception ex)
            {
                throw new OneBuckException("Error deserializing response", ex);
            }

            return userInfo;
        }
    }
}