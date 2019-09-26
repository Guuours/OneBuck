using Catalyzer.Conversion;
using Catalyzer.Cryptography;
using Catalyzer.Math;
using Newtonsoft.Json;
using OneBuck.WeChat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OneBuck.WeChat
{
    public class MP : Invoker
    {
        public static MPAccessTokenResp GetAccessToken(string appId, string appSecret)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appId}&secret={appSecret}";

            return RequestFor<MPAccessTokenResp>(url);
        }

        public static MPServerAddressResp GetServerAddress(string accessToken)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={accessToken}";

            return RequestFor<MPServerAddressResp>(url);
        }

        public static MPUserInfoResp GetUserInfo(string accessToken, string openId)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={accessToken}&openid={openId}&lang=zh_CN";

            return RequestFor<MPUserInfoResp>(url);
        }

        public static MPUserListResp GetUserList(string accessToken, string nextOpenId = null)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/user/get?access_token={accessToken}&next_openid={nextOpenId}";

            return RequestFor<MPUserListResp>(url);
        }

        public static MPTemplateListResp GetTemplateList(string accessToken)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={accessToken}";

            return RequestFor<MPTemplateListResp>(url);
        }

        public static MPMessageResp SendTemplateMessage(string accessToken, string openId, string templateId, Dictionary<string, MPMessageParameter> @params, string jumpUrl = null)
        {
            var payload = new
            {
                touser = openId,
                template_id = templateId,
                data = @params,
                url = jumpUrl
            };

            var url = $"https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={accessToken}";

            return RequestFor<MPMessageResp>(url, payload);
        }

        public static MPSessionKeyResp GetSessionKey(string code, string appId, string secret)
        {
            var url = $"https://api.weixin.qq.com/sns/jscode2session?appid={appId}&secret={secret}&js_code={code}&grant_type=authorization_code";

            return RequestFor<MPSessionKeyResp>(url);
        }

        public static JsTicketResp GetJsTicket(string accessToken)
        {
            var url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";

            return RequestFor<JsTicketResp>(url);
        }

        public static JsSignature GetJsSignature(string ticket, string url)
        {
            var nonceString = Randomness.RandomText(16, RandomTextOption.All);
            var timestamp = DateTime.Now.ToUnixEpoch();
            var raw = $"jsapi_ticket={ticket}&noncestr={nonceString}&timestamp={timestamp}&url={url}";
            var signature = raw.SHA1().ToLower();

            return new JsSignature
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

        public static MPUserInfoResp DecryptData(string sessionKey, string iv, string data)
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

            MPUserInfoResp userInfo;
            try
            {
                userInfo = JsonConvert.DeserializeObject<MPUserInfoResp>(output);
            }
            catch(Exception ex)
            {
                throw new OneBuckException("Error deserializing response", ex);
            }

            return userInfo;
        }
    }
}