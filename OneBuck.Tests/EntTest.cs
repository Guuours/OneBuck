using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OneBuck.Tests
{
    [TestClass]
    public class EntTest
    {
        [TestMethod]
        public void RoundTripTest()
        {
            var at = ENT.GetAccessToken("wwcc94791802109e81", "XpJEbAP_DrNg2L6KzRP8CpOylYahjnknKtc1QfCZYeA");
            var depts = ENT.GetDepartmentList(at.AccessToken);
            var deptUsers = ENT.GetSimpleUserList(at.AccessToken, 1);
            var user = ENT.GetUser(at.AccessToken, "guuours");
            var ret = ENT.SendText(at.AccessToken, "guuours", null, null, "1000002", "点<a href=\"https://www.baidu.com\">这里</a>看hb的小秘密");
        }
    }
}