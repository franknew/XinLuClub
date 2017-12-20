using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DAL
{
    public class TopicDetail
    {
        public FullTopicInfo Topic { get; set; }
        public PaginationEntity<ReplyWithChild> Replies { get; set; }
    }
}
