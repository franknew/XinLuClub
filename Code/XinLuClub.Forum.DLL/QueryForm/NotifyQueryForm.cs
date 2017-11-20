using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Form
{
    public partial class NotifyQueryForm : SimpleQueryForm
    {
        public List<string> IDs { get; set;}
        public string TopicID { get; set; }
        
        public List<string> TopicIDs { get; set;}
        public string ReplyID { get; set; }
        
        public List<string> ReplyIDs { get; set;}
        public Boolean? IsRead { get; set; }
        
        public string UserID { get; set; }
        
        public List<string> UserIDs { get; set;}
    }
}
