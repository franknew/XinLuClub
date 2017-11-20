using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Form
{
    public partial class User_TopicGroupQueryForm : BaseQueryForm
    {
        public List<string> IDs { get; set;}
        public string UserID { get; set; }
        
        public List<string> UserIDs { get; set;}
        public string TopicGroupID { get; set; }
        
        public List<string> TopicGroupIDs { get; set;}
    }
}
