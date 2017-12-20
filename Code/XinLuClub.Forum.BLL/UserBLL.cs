using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAFramework.Library;
using XinLuClub.Forum.DAL;

namespace XinLuClub.Forum.BLL
{
    public class UserBLL
    {
        public string Add(FullUserInfo user)
        {
            var mapper = Common.GetMapper();
            UserDao userDao = new UserDao(mapper);
            var repeateUser = userDao.Query(new UserQueryForm { Name = user.Name }).FirstOrDefault();
            if (repeateUser != null) throw new XinLuClubException(402, "用户名已存在");
            var result = userDao.Add(user);
            if (user.Boards != null)
            {
                User_BoardGroupDao ubdao = new User_BoardGroupDao(mapper);
                user.Boards.ForEach(t =>
                {
                    User_BoardGroup ub = new User_BoardGroup
                    {
                        UserID = result.ID,
                        BoardGroupID = t.ID,
                    };
                    ubdao.Add(ub);
                });
            }

            return result.ID;
        }

        public bool UpdatePassword(UserPassword userPassword)
        {
            var mapper = Common.GetMapper();
            UserPasswordDao updao = new UserPasswordDao(mapper);

            return updao.Update(new UserPasswordUpdateForm
            {
                Entity = new UserPassword { Password = userPassword.Password },
                QueryForm = new UserPasswordQueryForm { UserName = userPassword.UserName },
            });
        }

        public bool ResetPassword(string userID, string password)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            UserPasswordDao updao = new UserPasswordDao(mapper);
            var user = userdao.Query(new UserQueryForm { ID = userID }).FirstOrDefault();
            if (user == null) throw new XinLuClubException(202, "用户不存在");
            var up = updao.Query(new UserPasswordQueryForm { UserName = user.Name }).FirstOrDefault();
            if (up == null) updao.Add(new UserPassword { UserName = user.Name, Password = password });
            else updao.Update(new UserPasswordUpdateForm
            {
                Entity = new UserPassword { Password = password },
                QueryForm = new UserPasswordQueryForm { UserName = user.Name },
            });
            return true;
        }

        public bool Delete(UserQueryForm form)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            return userdao.Delete(form);
        }

        public bool Update(FullUserInfo user)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            User_BoardGroupDao ubdao = new User_BoardGroupDao(mapper);
            ubdao.Delete(new User_BoardGroupQueryForm { UserID = user.ID });
            if (user.Boards != null)
            {
                user.Boards.ForEach(t =>
                {
                    User_BoardGroup ub = new User_BoardGroup
                    {
                        UserID = user.ID,
                        BoardGroupID = t.ID,
                    };
                    ubdao.Add(ub);
                });
            }
            return userdao.Update(new UserUpdateForm {
                Entity = new User
                {
                    WeiXin = user.WeiXin,
                    Enabled = user.Enabled,
                    Gender = user.Gender,
                    IdentityCode = user.IdentityCode,
                    IsAdmin = user.IsAdmin,
                    Mobile = user.Mobile,
                    RealName = user.RealName,
                },
                QueryForm = new UserQueryForm { ID = user.ID }
            });
        }

        public bool Update(UserUpdateForm form)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            return userdao.Update(form);
        }

        public PaginationEntity<FullUserInfo> Query(UserQueryForm form)
        {
            PaginationEntity<FullUserInfo> result = new PaginationEntity<FullUserInfo>();
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            User_BoardGroupDao ubdao = new User_BoardGroupDao(mapper);
            BoardGroupDao bgdao = new BoardGroupDao(mapper);
            var users = userdao.Query(form);
            var userids = (from u in users
                       select u.ID).ToList();
            var ubs = ubdao.Query(new User_BoardGroupQueryForm { UserIDs = userids });
            var allboards = bgdao.Query(new BoardGroupQueryForm { Enabled = true });
            List<FullUserInfo> list = new List<FullUserInfo>();
            users.ForEach(u =>
            {
                var boards = (from ub in ubs
                              join b in allboards on ub.BoardGroupID equals b.ID
                              where ub.UserID == u.ID
                              select b).ToList();
                var fulluser = new FullUserInfo();
                u.CopyTo<FullUserInfo>(fulluser);
                fulluser.Boards = boards;
                list.Add(fulluser);
            });
            result.RecordCount = form.RecordCount;
            result.List = list;
            return result;
        }
    }
}
