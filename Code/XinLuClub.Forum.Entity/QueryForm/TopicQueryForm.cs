using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class TopicQueryForm : BaseQueryForm
    {
        public string ID { get; set; }
        
        public List<string> IDs { get; set;}
        public string Name { get; set; }
        
        public string Content { get; set; }
        
        public DateTime? CreateTime { get; set; }
        
        public DateTime? CreateTime_Start { get; set; }
        
        public DateTime? CreateTime_End { get; set; }
        
        public DateTime? LastUpdateTime { get; set; }
        
        public DateTime? LastUpdateTime_Start { get; set; }
        
        public DateTime? LastUpdateTime_End { get; set; }
        
        public string OwnerID { get; set; }
        
        public List<string> OwnerIDs { get; set;}
        public string LastReplierID { get; set; }
        
        public List<string> LastReplierIDs { get; set;}
        public Int32? ReplyCount { get; set; }
        
        public Int32? ReplyCount_Start { get; set; }
        
        public Int32? ReplyCount_End { get; set; }
        
        public string TopicGroupID { get; set; }
        
        public List<string> TopicGroupIDs { get; set;}
        public string BoardGroupID { get; set; }
        
        public List<string> BoardGroupIDs { get; set;}
        public Boolean? Enabled { get; set; }
        
    }
}
