using IBatisNet.DataMapper;
using SOAFramework.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using XinLuClub.Forum.BLL;

namespace XinLuClub.Forum.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorityFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = Common.GetToken();
            //权限验证
            LoginBLL userBLL = new LoginBLL();
            var user = userBLL.CheckLogin(token);
            if (user == null) throw new XinLuClubException(100, "token已失效,请重新登录");
        }

    }
}