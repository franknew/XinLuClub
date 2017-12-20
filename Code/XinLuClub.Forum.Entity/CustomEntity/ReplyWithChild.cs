using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DAL
{
    public class ReplyWithChild: FullReplyInfo
    {
        private List<ReplyWithChild> children = new List<ReplyWithChild>();
        public List<ReplyWithChild> Children { get => children; set => children = value; }
    }
}
