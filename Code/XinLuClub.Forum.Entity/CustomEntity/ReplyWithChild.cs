using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DLL.Entity
{
    public class ReplyWithChild: Reply
    {
        public List<ReplyWithChild> Children { get; set; }

        public string ReplyToName { get; set; }
        public string OwnerName { get; set; }
    }
}
