using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
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
    public class TopicController : ApiController
    {
        TopicBLL bll = new TopicBLL();

        [HttpPost]
        public string AddTopic(Topic topic)
        {
            if (topic == null) throw new XinLuClubException(400, "topic不能为null");
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            topic.OwnerID = me.ID;
            return bll.AddTopic(topic);
        }

        [HttpPost]
        public string AddReply(Reply reply)
        {
            if (reply == null) throw new XinLuClubException(400, "reply不能为null");
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            reply.OwnerID = me.ID;
            return bll.AddReply(reply);
        }
        
        [AcceptVerbs("GET", "POST")]
        public bool DeleteReply(string replyID)
        {
            if (replyID == null) throw new XinLuClubException(400, "replyID不能为空");
            return bll.DeleteReply(replyID);
        }

        [AcceptVerbs("GET", "POST")]
        public List<BoardGroup> GetBoardGroupList()
        {
            return bll.GetMyBoardGroupList();
        }

        [AcceptVerbs("GET", "POST")]
        public PaginationEntity<FullTopicInfo> GetActiveTopicList(int pageSize, int currentPageIndex)
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.GetFullTopicList(new TopicQueryForm { OwnerID = me.ID, PageSize = pageSize, CurrentIndex = currentPageIndex, OrderBy = OrderBy.DESC, OrderByColumn = "LastUpdateTime", Enabled = true });
        }

        [AcceptVerbs("GET", "POST")]
        public PaginationEntity<FullTopicInfo> GetNewestTopicList(int pageSize, int currentPageIndex)
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.GetFullTopicList(new TopicQueryForm { OwnerID = me.ID, PageSize = pageSize, CurrentIndex = currentPageIndex, OrderBy = OrderBy.DESC, OrderByColumn = "CreateTime", Enabled = true });
        }

        [AcceptVerbs("GET", "POST")]
        public PaginationEntity<FullTopicInfo> GetTopicListByBoard(string boardID, int pageSize, int currentPageIndex)
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.GetFullTopicListByBoard(new TopicQueryForm { OwnerID = me.ID, Enabled = true, PageSize = pageSize, CurrentIndex = currentPageIndex, OrderBy = OrderBy.DESC, OrderByColumn = "LastUpdateTime", BoardGroupID = boardID });
        }


        [AcceptVerbs("GET", "POST")]
        public TopicDetail GetTopicDetail(string topicID, int pageSize, int currentPageIndex)
        {
            return bll.GetTopicDetail(topicID, pageSize, currentPageIndex);
        }

        [AcceptVerbs("GET", "POST")]
        public bool DeleteTopic(string topicID)
        {
            if (topicID == null) throw new XinLuClubException(400, "topicID不能为空");
            return bll.DeleteTopic(new TopicQueryForm { TopicGroupID = topicID });
        }

        [AcceptVerbs("GET", "POST")]
        public PaginationEntity<FullTopicInfo> MyTopicList(int pageSize, int currentPageIndex)
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.GetMyFullTopicList(new TopicQueryForm
            {
                OwnerID = me.ID,
                Enabled = true,
                OrderBy = OrderBy.DESC,
                OrderByColumn = "CreateTime",
                PageSize = pageSize,
                CurrentIndex = currentPageIndex,
            });
        }

        [AcceptVerbs("GET", "POST")]
        public int GetMyUnreadReplyCount()
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.GetReplyCount(new QueryNotifyReplyForm
            {
                Enabled = true,
                ReplyTo = me.ID,
                IsRead = false,
            });
        }

        [AcceptVerbs("GET", "POST")]
        public PaginationEntity<FullReplyInfo> GetMyReply(int pageSize, int currentPageIndex)
        {
            LoginBLL login = new LoginBLL();
            var me = login.GetMe();
            return bll.GetReplyList(new QueryNotifyReplyForm
            {
                Enabled = true,
                ReplyTo = me.ID,
            });
        }

        [AcceptVerbs("GET", "POST")]
        public bool ReadReply(string replyID)
        {
            return bll.Read(new NotifyQueryForm
            {
                ReplyID = replyID,
            });
        }

        [AcceptVerbs("GET", "POST")]
        public FullReplyInfo GetReplyDetailList(string replyID)
        {
            return bll.GetReplyDetailList(replyID);
        }
    }
}
