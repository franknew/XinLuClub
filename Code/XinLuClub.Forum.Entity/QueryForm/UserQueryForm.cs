using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Form
{
    public partial class UserQueryForm : SimpleQueryForm
    {
        public List<string> IDs { get; set;}
        public string Name { get; set; }
        
        public Boolean? Gender { get; set; }
        
        public string IdentityCode { get; set; }
        
        public string Mobile { get; set; }
        
        public Boolean? Enabled { get; set; }
        
        public Boolean? IsAdmin { get; set; }
        
        public string RealName { get; set; }
        
        public string WeiXin { get; set; }
        
    }
}
