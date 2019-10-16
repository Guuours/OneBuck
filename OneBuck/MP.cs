using Catalyzer.Conversion;
using Catalyzer.Cryptography;
using Catalyzer.Math;
using Newtonsoft.Json;
using OneBuck.Models.MP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OneBuck
{
    public class MP : Invoker
    {
        public static MPAccessToken GetAccessToken(string appId, string appSecret)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={appSecret}";

            return RequestFor<MPAccessToken>(reqUrl);
        }

        public static MPServerAddress GetServerAddress(string accessToken)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={accessToken}";

            return RequestFor<MPServerAddress>(reqUrl);
        }

        public static MPUserInfo GetUserInfo(string accessToken, string openId)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={accessToken}&openid={openId}&lang=zh_CN";

            return RequestFor<MPUserInfo>(reqUrl);
        }

        public static MPUserList GetUserList(string accessToken, string nextOpenId = null)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/user/get?access_token={accessToken}&next_openid={nextOpenId}";

            return RequestFor<MPUserList>(reqUrl);
        }

        public static MPTemplateList GetTemplateList(string accessToken)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={accessToken}";

            return RequestFor<MPTemplateList>(reqUrl);
        }

        public static MPMessageResult SendTemplateMessage(string accessToken, string openId, string templateId, Dictionary<string, MPMessageParameter> @params, string jumpUrl = null)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={accessToken}";

            var payload = new
            {
                touser = openId,
                template_id = templateId,
                data = @params,
                url = jumpUrl
            };

            return RequestFor<MPMessageResult>(reqUrl, payload);
        }

        public static MPSessionKey GetSessionKey(string code, string appId, string secret)
        {
            var reqUrl = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={code}&grant_type=authorization_code";

            return RequestFor<MPSessionKey>(reqUrl);
        }

        public static MPJsTicket GetJsTicket(string accessToken)
        {
            var reqUrl = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";

            return RequestFor<MPJsTicket>(reqUrl);
        }

        public static MPJsSignature GetJsSignature(string ticket, string url)
        {
            var nonceString = Randomness.RandomText(16, RandomTextOption.All);
            var timestamp = DateTime.Now.ToUnixEpoch();
            var raw = $"jsapi_ticket={ticket}&noncestr={nonceString}&timestamp={timestamp}&url={url}";
            var signature = raw.SHA1().ToLower();

            return new MPJsSignature
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

        public static MPUserInfo DecryptData(string sessionKey, string iv, string data)
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

            MPUserInfo userInfo;
            try
            {
                userInfo = JsonConvert.DeserializeObject<MPUserInfo>(output);
            }
            catch (Exception ex)
            {
                throw new OneBuckException("Error deserializing response", ex);
            }

            return userInfo;
        }
    }
}