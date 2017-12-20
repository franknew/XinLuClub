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
    public class TransactionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Common.StoreMapper();
            Common.BeginTrans();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception == null) Common.CommitTrans();
            ContextFactory.RemoveCurrent();
        }
    }
}