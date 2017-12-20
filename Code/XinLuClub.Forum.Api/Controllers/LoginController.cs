using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XinLuClub.Forum.Api;
using XinLuClub.Forum.BLL;
using XinLuClub.Forum.DAL;

namespace XinLuClub.Api.Controllers
{
    [TransactionFilter]
    [ExceptionHandlerFilter]
    public class LoginController : ApiController
    {
        LoginBLL bll = new LoginBLL();
        
        [AcceptVerbs("GET", "POST")]
        public LoginResult Login(string userName, string password)
        {
            return bll.Login(userName, password);
        }
    }
}
