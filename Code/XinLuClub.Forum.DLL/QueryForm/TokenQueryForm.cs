using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Form
{
    public partial class TokenQueryForm : SimpleQueryForm
    {
        public List<string> IDs { get; set;}
        public string AccessToken { get; set; }
        
        public Boolean? Enabled { get; set; }
        
        public string UserID { get; set; }
        
        public List<string> UserIDs { get; set;}
        public DateTime? ExpiredTime { get; set; }
        
        public DateTime? ExpiredTime_Start { get; set; }
        
        public DateTime? ExpiredTime_End { get; set; }
        
    }
}
