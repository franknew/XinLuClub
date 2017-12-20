using SOAFramework.Library;
using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinLuClub.Forum.DAL;

namespace XinLuClub.Forum.BLL
{
    public class IndexBLL
    {
        public IndexPage Index(int pageSize)
        {
            LoginBLL loginbll = new LoginBLL();
            TopicBLL topicbll = new TopicBLL();
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            User_BoardGroupDao utgdao = new User_BoardGroupDao(mapper);
            BoardGroupDao tgdao = new BoardGroupDao(mapper);
            TopicDao topicdao = new TopicDao(mapper);

            var me = loginbll.GetMe();
            if (me == null) throw new XinLuClubException(100, "token过期，请重新登录");
            var utgs = utgdao.Query(new User_BoardGroupQueryForm { UserID = me.ID });
            var groups = new List<BoardGroup>();
            var topicinfos = new PaginationEntity<FullTopicInfo>();
            if (utgs.Count > 0)
            {
                var groupIDs = (from u in utgs
                                select u.BoardGroupID).ToList();

                groups = tgdao.Query(new BoardGroupQueryForm { IDs = groupIDs, Enabled = true, OrderBy = OrderBy.DESC, OrderByColumn = "LastUpdateTime" });

                topicinfos = topicbll.GetFullTopicList(new TopicQueryForm { PageSize = pageSize, CurrentIndex = 1, OrderBy = OrderBy.DESC, OrderByColumn = "LastUpdateTime", OwnerID = me.ID });
            }
            IndexPage page = new IndexPage
            {
                //ActiveTopics = activeTopic,
                NewestTopics = topicinfos,
                BoardGroups = groups,
            };
            return page;
        }

        public bool ChangePassword(string userID, string oldPassword, string newPassword)
        {
            var mappper = Common.GetMapper();
            UserPasswordDao updao = new UserPasswordDao(mappper);
            var user = updao.QuerySingle(new UserPasswordQueryForm { ID = userID, Password = oldPassword });
            if (user == null) throw new XinLuClubException(102, "用户或者密码错误");
            updao.Update(new UserPasswordUpdateForm
            {
                Entity = new UserPassword
                {
                    Password = newPassword,
                },
                QueryForm = new UserPasswordQueryForm
                {
                    ID = userID
                },
            });

            return true;
        }
    }
}
