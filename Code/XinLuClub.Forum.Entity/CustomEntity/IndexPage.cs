using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DLL.Entity
{
    public class IndexPage
    {
        public List<BoardGroup> BoardGroups { get; set; }
        public PaginationEntity<FullTopicInfo> NewestTopics { get; set; }
        public PaginationEntity<FullTopicInfo> ActiveTopics { get; set; }
    }
}
