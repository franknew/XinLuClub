using SOAFramework.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using XinLuClub.Forum.BLL;

namespace XinLuClub.Forum.Api
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Common.RollBackTrans();
            var ex = actionExecutedContext.Exception as XinLuClubException;
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            if (ex != null && ex.Code == 100) status = HttpStatusCode.Unauthorized;
            if (ex != null && ex.Code == 101) status = HttpStatusCode.MethodNotAllowed;
            var oResponse = new HttpResponseMessage(status);
            oResponse.Content = new StringContent(actionExecutedContext.Exception.Message);
            //oResponse.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = oResponse;
            SimpleLogger logger = new SimpleLogger();
            logger.WriteException(actionExecutedContext.Exception);
        }
    }
}