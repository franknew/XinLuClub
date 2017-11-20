using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinLuClub.Forum.DLL.Dao;
using XinLuClub.Forum.DLL.Entity;
using XinLuClub.Forum.DLL.Form;

namespace XinLuClub.Forum.BLL
{
    public class TopicBLL
    {
        public TopicDetail GetTopicDetail(string topicID, int pageSize, int currentPageIndex)
        {
            var mapper = Common.GetMapper();
            TopicDao topicdao = new TopicDao(mapper);
            ReplyDao replydao = new ReplyDao(mapper);
            var topic = topicdao.QueryFullTopicInfo(new TopicQueryForm { ID = topicID, Enabled = true }).FirstOrDefault();
            var replies = GetReplies(new ReplyQueryForm {
                TopicID = topicID,
                ReplyID = "0",
                OrderBy = OrderBy.ASC,
                OrderByColumn = "CreateTime",
                PageSize = pageSize,
                CurrentIndex = currentPageIndex,
                Enabled = true,
            });

            return new TopicDetail { Topic = topic, Replies = replies };
        }

        public PaginationEntity<FullTopicInfo> GetFullTopicListByBoard(TopicQueryForm form)
        {
            var mapper = Common.GetMapper();
            TopicDao topicdao = new TopicDao(mapper);
            User_BoardGroupDao udgdao = new User_BoardGroupDao(mapper);
            var paging = new PaginationEntity<FullTopicInfo>();
            var boards = udgdao.Query(new User_BoardGroupQueryForm { UserID = form.OwnerID, BoardGroupID = form.BoardGroupID });
            if (boards.Count == 0) throw new XinLuClubException(202, "你没有查看该板块的权限，请联系管理员");
            var topics = topicdao.QueryFullTopicInfo(form);
            paging.List = topics;
            paging.RecordCount = form.RecordCount;
            return paging;
        }

        public PaginationEntity<FullTopicInfo> GetFullTopicList(TopicQueryForm form)
        {
            var mapper = Common.GetMapper();
            TopicDao topicdao = new TopicDao(mapper);
            User_BoardGroupDao udgdao = new User_BoardGroupDao(mapper);
            var paging = new PaginationEntity<FullTopicInfo>();
            var boards = udgdao.Query(new User_BoardGroupQueryForm { UserID = form.OwnerID });
            var boardids = (from b in boards
                            select b.ID).ToList();
            var topics = topicdao.QueryFullTopicInfo(form);
            paging.List = topics;
            paging.RecordCount = form.RecordCount;
            return paging;
        }

        public string AddTopic(Topic topic)
        {
            var mapper = Common.GetMapper();
            TopicDao dao = new TopicDao(mapper);
            return dao.Add(topic);
        }

        public string AddReply(Reply reply)
        {
            var mapper = Common.GetMapper();
            
            ReplyDao replydao = new ReplyDao(mapper);
            TopicDao topicdao = new TopicDao(mapper);
            topicdao.UpdateReplyCount(new TopicQueryForm
            {
                ID = reply.TopicID,
                LastReplierID = reply.Creator,
            });

            return replydao.Add(reply);
        }

        public bool DeleteReply(string replyID)
        {
            var mapper = Common.GetMapper();
            ReplyDao dao = new ReplyDao(mapper);
            return dao.Delete(new ReplyQueryForm { ID = replyID });
        }

        public List<BoardGroup> GetMyBoardGroupList()
        {
            LoginBLL login = new LoginBLL();
            var mapper = Common.GetMapper();
            var me = login.GetMe();
            BoardGroupDao bgdao = new BoardGroupDao(mapper);
            User_BoardGroupDao ubgdao = new User_BoardGroupDao(mapper);
            var boards = ubgdao.Query(new User_BoardGroupQueryForm { UserID = me.ID });
            var boardids = (from b in boards
                            select b.ID).ToList();
            var boardGroups = bgdao.Query(new BoardGroupQueryForm { Enabled = true, IDs = boardids });

            return boardGroups;
        }

        public PaginationEntity<ReplyWithChild> GetReplies(ReplyQueryForm form)
        {
            PaginationEntity<ReplyWithChild> paging = new PaginationEntity<ReplyWithChild>();
            var mapper = Common.GetMapper();
            ReplyDao replydao = new ReplyDao(mapper);
            var firstReplies = replydao.QueryFullReplyInfo(form);

            var replyids = (from r in firstReplies
                            select r.ID).ToList();
            var chilren = replydao.QueryFullReplyInfo(new ReplyQueryForm { ReplyIDs = replyids, Enabled = true, OrderByColumn = "CreateTime", OrderBy = OrderBy.ASC });
            //chilren.Sort((l, r) =>
            //{
            //    return Convert.ToInt16(l.CreateTime < r.CreateTime);
            //});

            firstReplies.ForEach(t =>
            {
                t.Children = new List<ReplyWithChild>();
                for (int i = 0; i < chilren.Count; i++)
                {
                    var reply = chilren[i];
                    if (t.ID.Equals(reply.ReplyID))
                    {
                        t.Children.Add(reply);
                        chilren.Remove(reply);
                        i--;
                    }
                }
            });
            paging.List = firstReplies;
            paging.RecordCount = form.RecordCount;

            return paging;
        }

        public string AddBoard(BoardGroup board)
        {
            var mapper = Common.GetMapper();
            BoardGroupDao dao = new BoardGroupDao(mapper);
            return dao.Add(board);
        }

        public bool UpdateBoard(BoardGroupUpdateForm form)
        {
            var mapper = Common.GetMapper();
            BoardGroupDao dao = new BoardGroupDao(mapper);
            return dao.Update(form);
        }

        public bool DeleteBoard(BoardGroupQueryForm form)
        {
            var mapper = Common.GetMapper();
            BoardGroupDao dao = new BoardGroupDao(mapper);
            return dao.Delete(form);
        }

        public List<BoardGroup> GetBoardGroupList(BoardGroupQueryForm form)
        {
            var mapper = Common.GetMapper();
            BoardGroupDao dao = new BoardGroupDao(mapper);
            return dao.Query(form);
        }

        private List<ReplyWithChild> BuildTree(List<ReplyWithChild> list)
        {
            List<ReplyWithChild> nodes = list.FindAll(t => string.IsNullOrEmpty(t.ReplyID));
            foreach (var n in nodes)
            {
                BuildTree_Resc(list, n);
            }
            return nodes;
        }

        private void BuildTree_Resc(List<ReplyWithChild> list, ReplyWithChild node)
        {
            var nodes = list.FindAll(t => t.ID.Equals(node.ID));
            foreach (var n in nodes)
            {
                node.Children.Add(n);
                BuildTree_Resc(list, n);
            }
        }

        public List<FullTopicInfo> SearchMyTopic(string searchContent, string userID)
        {
            var mappper = Common.GetMapper();
            TopicDao dao = new TopicDao(mappper);
            return dao.SearchMyTopic(new SearchMyTopicForm { SearchCotent = searchContent, UserID = userID });
        }

    }
}
