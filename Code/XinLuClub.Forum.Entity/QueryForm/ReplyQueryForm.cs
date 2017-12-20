using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class ReplyQueryForm : BaseQueryForm
    {
        public string ID { get; set; }
        
        public List<string> IDs { get; set;}
        public string Content { get; set; }
        
        public string OwnerID { get; set; }
        
        public List<string> OwnerIDs { get; set;}
        public DateTime? CreateTime { get; set; }
        
        public DateTime? CreateTime_Start { get; set; }
        
        public DateTime? CreateTime_End { get; set; }
        
        public string ReplyID { get; set; }
        
        public List<string> ReplyIDs { get; set;}
        public string TopicID { get; set; }
        
        public List<string> TopicIDs { get; set;}
        public string ReplyTo { get; set; }
        
        public Boolean? Enabled { get; set; }
        
        public DateTime? LastUpdateTime { get; set; }
        
        public DateTime? LastUpdateTime_Start { get; set; }
        
        public DateTime? LastUpdateTime_End { get; set; }
        
        public string ReplyToID { get; set; }
        
        public List<string> ReplyToIDs { get; set;}
    }
}
