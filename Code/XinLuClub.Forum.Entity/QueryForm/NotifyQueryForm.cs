using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class NotifyQueryForm : BaseQueryForm
    {
        public string ID { get; set; }
        
        public List<string> IDs { get; set;}
        public string TopicID { get; set; }
        
        public List<string> TopicIDs { get; set;}
        public string ReplyID { get; set; }
        
        public List<string> ReplyIDs { get; set;}
        public Boolean? IsRead { get; set; }
        
        public string UserID { get; set; }
        
        public List<string> UserIDs { get; set;}
        public DateTime? CreateTime { get; set; }
        
        public DateTime? CreateTime_Start { get; set; }
        
        public DateTime? CreateTime_End { get; set; }
        
        public DateTime? LastUpdateTime { get; set; }
        
        public DateTime? LastUpdateTime_Start { get; set; }
        
        public DateTime? LastUpdateTime_End { get; set; }
        
    }
}
