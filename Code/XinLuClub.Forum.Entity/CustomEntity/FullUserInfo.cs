using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DLL.Entity
{
    public class FullUserInfo: User
    {
        public List<BoardGroup> Boards { get; set; }
    }
}
