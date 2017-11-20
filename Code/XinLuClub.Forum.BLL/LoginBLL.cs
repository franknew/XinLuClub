using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOAFramework.Library.DAL;
using XinLuClub.Forum.DLL.Entity;
using XinLuClub.Forum.DLL.Dao;
using XinLuClub.Forum.DLL.Form;
using SOAFramework.Library;
using System.Web;

namespace XinLuClub.Forum.BLL
{
    public class LoginBLL
    {
        const string meKey = "__me";

        public LoginResult Login(string userName, string password)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            TokenDao tokendao = new TokenDao(mapper);
            UserPasswordDao updao = new UserPasswordDao(mapper);

            var ups = updao.Query(new UserPasswordQueryForm { UserName = userName, Password = password });
            if (ups == null || ups.Count == 0) throw new XinLuClubException(102, "账号或者密码错误");
            var users = userdao.Query(new UserQueryForm { Name = userName });
            if (users == null || users.Count == 0) throw new XinLuClubException(103, "账号信息不存在");
            var user = users[0];
            var userid = user.ID;

            var tokens = tokendao.Query(new TokenQueryForm { UserID = userid });
            IIDGenerator generator = IDGeneratorFactory.Create(GeneratorType.GUID);
            string tokenstring = generator.Generate();
            Token token = null;
            if (tokens == null || tokens.Count == 0)
            {
                token = new Token
                {
                    ExpiredTime = DateTime.Now.AddHours(2),
                    UserID = userid,
                    AccessToken = tokenstring,
                };
                tokendao.Add(token);
            }
            else
            {
                token = tokens[0];
                token.ExpiredTime = DateTime.Now.AddHours(1);
                token.AccessToken = tokenstring;
                tokendao.Update(new TokenUpdateForm
                {
                    Entity = new Token
                    {
                        AccessToken = token.AccessToken,
                        ExpiredTime = token.ExpiredTime,
                    },
                    QueryForm = new TokenQueryForm
                    {
                        ID = token.ID,
                    }
                });
            }
            SaveMe(user);
            LoginResult result = new LoginResult
            {
                Token = token,
                User = user,
            };
            return result;
        }

        public void RefreshToken(string token)
        {
            var mapper = Common.GetMapper();
            TokenDao tokendao = new TokenDao(mapper);
            tokendao.Update(new TokenUpdateForm
            {
                Entity = new Token { ExpiredTime = DateTime.Now.AddHours(1) },
                QueryForm = new TokenQueryForm { AccessToken = token },
            });
        }

        public User GetUser(string userName)
        {
            var mapper = Common.GetMapper();
            UserDao dao = new UserDao(mapper);
            var users = dao.Query(new UserQueryForm { Name = userName });
            return users?[0];
        }

        public User GetUserByToken(string token)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            Token tokenEntity = GetToken(token);
            if (tokenEntity == null) return null;
            if (!string.IsNullOrEmpty(tokenEntity.UserID)) return null;
            return userdao.Query(new UserQueryForm { ID = tokenEntity.UserID.ToString() })?[0];
        }

        public Token GetToken(string token)
        {
            var mapper = Common.GetMapper();
            TokenDao tokendao = new TokenDao(mapper);
            var tokens = tokendao.Query(new TokenQueryForm { AccessToken = token });
            if (tokens == null || tokens.Count == 0) return null;
            return tokens[0];
        }

        public User CheckLogin(string token)
        {
            var mapper = Common.GetMapper();
            UserDao userdao = new UserDao(mapper);
            var tokenEntity = GetToken(token);
            if (tokenEntity == null) throw new XinLuClubException(100, "无效token,请重新登录");
            if (tokenEntity.ExpiredTime.Value < DateTime.Now) throw new XinLuClubException(100, "token已过期,请重新登陆");
            RefreshToken(token);
            var users = userdao.Query(new UserQueryForm { ID = tokenEntity.UserID.ToString() });
            return users[0];
        }

        public bool Logout(string token)
        {
            RemoveMe();
            return true;
        }

        public User GetMe()
        {
            User user = null;
            //if (Session.Current.ContainsKey(meKey)) user = Session.Current[meKey] as User;
            if (HttpContext.Current.Session[meKey] != null) user = HttpContext.Current.Session[meKey] as User;
            if (user == null) throw new XinLuClubException(100, "无效token，请重新登录");
            return user;
        }

        public void RemoveMe()
        {
            //Session.Current.Remove(meKey);
            HttpContext.Current.Session.Remove(meKey);
        }

        public void SaveMe(User user)
        {
            //Session.Current[meKey] = user;
            HttpContext.Current.Session[meKey] = user;
        }
    }
}
