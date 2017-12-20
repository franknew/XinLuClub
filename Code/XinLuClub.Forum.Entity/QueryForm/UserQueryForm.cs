using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class UserQueryForm : BaseQueryForm
    {
        public string ID { get; set; }
        
        public List<string> IDs { get; set;}
        public string Name { get; set; }
        
        public Boolean? Gender { get; set; }
        
        public string IdentityCode { get; set; }
        
        public string Mobile { get; set; }
        
        public Boolean? Enabled { get; set; }
        
        public DateTime? CreateTime { get; set; }
        
        public DateTime? CreateTime_Start { get; set; }
        
        public DateTime? CreateTime_End { get; set; }
        
        public Boolean? IsAdmin { get; set; }
        
        public string RealName { get; set; }
        
        public string WeiXin { get; set; }
        
        public DateTime? LastUpdateTime { get; set; }
        
        public DateTime? LastUpdateTime_Start { get; set; }
        
        public DateTime? LastUpdateTime_End { get; set; }
        
    }
}
