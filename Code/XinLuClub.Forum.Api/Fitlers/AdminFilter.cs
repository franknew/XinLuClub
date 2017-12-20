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
    public class AdminFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            if (me.IsAdmin != 1) throw new XinLuClubException(101, "没有权限进行该操作,请联系管理员");
        }
    }
}