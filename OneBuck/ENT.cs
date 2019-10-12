using OneBuck.Models.ENT;
using OneBuck.Models.MP;

namespace OneBuck
{
    public class ENT : Invoker
    {
        public static MPAccessToken GetAccessToken(string corpId, string corpSecret)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={corpId}&corpsecret={corpSecret}";

            return RequestFor<MPAccessToken>(url);
        }

        public static ENTUserInfo GetUserInfo(string accessToken, string code)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={accessToken}&code={code}";

            return RequestFor<ENTUserInfo>(url);
        }

        public static ENTUser GetUser(string accessToken, string userId)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={accessToken}&userid={userId}";

            return RequestFor<ENTUser>(url);
        }

        public static ENTDepartmentList GetDepartment(string accessToken, int id)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={accessToken}&id={id}";

            return RequestFor<ENTDepartmentList>(url);
        }

        public static ENTDepartmentList GetDepartmentList(string accessToken)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={accessToken}";

            return RequestFor<ENTDepartmentList>(url);
        }

        public static ENTUserSimpleList GetSimpleUserList(string accessToken, int departmentId, bool recursive = false)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={accessToken}&department_id={departmentId}&fetch_child={(recursive ? 1 : 0)}";

            return RequestFor<ENTUserSimpleList>(url);
        }

        public static ENTMessageResult SendText(string accessToken, string toUser, string toParty, string toTag, string agentId, string content, bool safe = false, bool enableIdTrans = false)
        {
            var url = $"https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={accessToken}";

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

            return RequestFor<ENTMessageResult>(url, payload);
        }
    }
}
