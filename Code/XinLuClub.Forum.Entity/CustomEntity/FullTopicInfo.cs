using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DLL.Entity
{
    public class FullTopicInfo: Topic
    {
        public string CreatorName { get; set; }
        public string LastReplyName { get; set; }
    }
}
