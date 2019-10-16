using Catalyzer.Conversion;
using Catalyzer.Cryptography;
using Catalyzer.Math;
using OneBuck.Models.ENT;
using OneBuck.Models.MP;
using System;

namespace OneBuck
{
    public class ENT : Invoker
    {
        public static MPAccessToken GetAccessToken(string corpId, string corpSecret)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={corpId}&corpsecret={corpSecret}";

            return RequestFor<MPAccessToken>(reqUrl);
        }

        public static ENTUserInfo GetUserInfo(string accessToken, string code)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={accessToken}&code={code}";

            return RequestFor<ENTUserInfo>(reqUrl);
        }

        public static ENTUser GetUser(string accessToken, string userId)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={accessToken}&userid={userId}";

            return RequestFor<ENTUser>(reqUrl);
        }

        public static ENTDepartmentList GetDepartment(string accessToken, int id)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={accessToken}&id={id}";

            return RequestFor<ENTDepartmentList>(reqUrl);
        }

        public static ENTDepartmentList GetDepartmentList(string accessToken)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={accessToken}";

            return RequestFor<ENTDepartmentList>(reqUrl);
        }

        public static ENTUserSimpleList GetSimpleUserList(string accessToken, int departmentId, bool recursive = false)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={accessToken}&department_id={departmentId}&fetch_child={(recursive ? 1 : 0)}";

            return RequestFor<ENTUserSimpleList>(reqUrl);
        }

        public static ENTMessageResult SendText(string accessToken, string toUser, string toParty, string toTag, string agentId, string content, bool safe = false, bool enableIdTrans = false)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={accessToken}";

            var payload = new
            {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "text",
                agentid = agentId,
                text = new
                {
                    content
                },
                safe = safe ? 1 : 0,
                enable_id_trans = enableIdTrans ? 1 : 0
            };

            return RequestFor<ENTMessageResult>(reqUrl, payload);
        }

        public static ENTMessageResult SendTextCard(string accessToken, string toUser, string toParty, string toTag, string agentId, string title,
            string description, string url, string btntxt, bool enableIdTrans = false)
        {
            var reqUrl = $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={accessToken}";

            var payload = new
            {
                touser = toUser,
                toparty = toParty,
                totag = toTag,
                msgtype = "textcard",
                agentid = agentId,
                textcard = new
                {
                    title,
                    description,
                    url,
                    btntxt
                },
                enable_id_trans = enableIdTrans ? 1 : 0
            };

            return RequestFor<ENTMessageResult>(reqUrl, payload);
        }

        public static MPJsTicket GetJsTicket(string accessToken)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={accessToken}";

            return RequestFor<MPJsTicket>(url);
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
    }
}
