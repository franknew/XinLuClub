using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DAL
{
    public class LoginResult
    {
        public Token Token { get; set; }
        public User User { get; set; }
    }
}
