using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DAL
{
    public class FullReplyInfo: Reply
    {
        public string ReplyToName { get; set; }
        public string OwnerName { get; set; }
        public bool IsRead { get; set; }
    }
}
