using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XinLuClub.Forum.BLL;
using XinLuClub.Forum.DAL;

namespace XinLuClub.Forum.Api.Controllers
{
    [TransactionFilter]
    [AuthorityFilter]
    [ExceptionHandlerFilter]
    public class IndexController : ApiController
    {
        IndexBLL bll = new IndexBLL();

        [AcceptVerbs("GET", "POST")]
        public IndexPage Index()
        {
            int pageSize = 20;
            string pageSizeString = ConfigurationManager.AppSettings["PageSize"];
            if (!string.IsNullOrEmpty(pageSizeString)) pageSize = Convert.ToInt32(pageSizeString);
            return bll.Index(pageSize);
        }

        [AcceptVerbs("GET", "POST")]
        public bool Logout(string token)
        {
            LoginBLL loginbll = new LoginBLL();
            return loginbll.Logout(token);
        }

        [AcceptVerbs("GET", "POST")]
        public bool ChangeMyPassword(string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword)) throw new XinLuClubException(400, "没有oldPassword");
            if (string.IsNullOrEmpty(newPassword)) throw new XinLuClubException(400, "没有newPassword");
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.ChangePassword(me.ID, oldPassword, newPassword);
        }

        [AcceptVerbs("GET", "POST")]
        public List<FullTopicInfo> SearchMyTopic(string searchContent)
        {
            TopicBLL topicbll = new TopicBLL();
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();

            return topicbll.SearchMyTopic(searchContent, me.ID);
        }

        [HttpPost]
        public bool UpdateMe(User user)
        {
            if (user == null) throw new XinLuClubException(400, "user不能为null");
            if (string.IsNullOrEmpty(user.ID)) throw new XinLuClubException(400, "userID不能为空");
            UserBLL userbll = new UserBLL();
            user.Name = null;
            return userbll.Update(new UserUpdateForm
            {
                Entity = user,
                QueryForm = new UserQueryForm
                {
                    ID = user.ID,
                }
            });
        }
    }

}
