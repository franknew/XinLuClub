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
    [AdminFilter]
    public class AdminController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public PaginationEntity<FullUserInfo> GetUserList(UserQueryForm user)
        {
            if (user == null) throw new XinLuClubException(400, "user不能为null");
            UserBLL userbll = new UserBLL();
            return userbll.Query(user);
        }

        [HttpPost]
        public string AddUser(FullUserInfo user)
        {
            if (user == null) throw new XinLuClubException(400, "user不能为null");
            UserBLL userbll = new UserBLL();
            return userbll.Add(user);
        }

        [HttpPost]
        public bool UpdateUser(FullUserInfo user)
        {
            if (user == null) throw new XinLuClubException(400, "user不能为null");
            if (string.IsNullOrEmpty(user.ID)) throw new XinLuClubException(400, "userid不能为空");
            UserBLL userbll = new UserBLL();
            return userbll.Update(user);
        }

        [AcceptVerbs("GET", "POST")]
        public bool DeleteUser(string userID)
        {
            if (string.IsNullOrEmpty(userID)) throw new XinLuClubException(400, "userID不能为空");
            UserBLL userbll = new UserBLL();
            return userbll.Delete(new UserQueryForm { ID = userID });
        }

        [HttpPost]
        public bool UpdateBoard(BoardGroup board)
        {
            if (board == null) throw new XinLuClubException(400, "board不能为null");
            if (string.IsNullOrEmpty(board.ID)) throw new XinLuClubException(400, "boardID不能为空");
            TopicBLL bll = new TopicBLL();
            return bll.UpdateBoard(new BoardGroupUpdateForm
            {
                Entity = new BoardGroup
                {
                    Name = board.Name,
                    Description = board.Description,
                    Enabled = board.Enabled,
                },
                QueryForm = new BoardGroupQueryForm
                {
                    ID = board.ID
                }
            });
        }

        [HttpPost]
        public string AddBoard(BoardGroup board)
        {
            if (board == null) throw new XinLuClubException(400, "board不能为null");
            TopicBLL bll = new TopicBLL();
            return bll.AddBoard(board);
        }

        [AcceptVerbs("GET", "POST")]
        public bool DeleteBoard(string boardID)
        {
            if (string.IsNullOrEmpty(boardID)) throw new XinLuClubException(400, "boardID不能为空");
            TopicBLL bll = new TopicBLL();
            return bll.DeleteBoard(new BoardGroupQueryForm { ID = boardID });
        }

        [AcceptVerbs("GET", "POST")]
        public bool ResetPassword(string userID, string password)
        {
            UserBLL userbll = new UserBLL();
            return userbll.ResetPassword(userID, password);
        }

        public List<BoardGroup> GetBoardGroupList()
        {
            TopicBLL bll = new TopicBLL();
            return bll.GetBoardGroupList(new BoardGroupQueryForm { });
        }
    }
}
