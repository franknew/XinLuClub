using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class BoardGroupQueryForm : BaseQueryForm
    {
        public string ID { get; set; }
        
        public List<string> IDs { get; set;}
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime? CreateTime { get; set; }
        
        public DateTime? CreateTime_Start { get; set; }
        
        public DateTime? CreateTime_End { get; set; }
        
        public DateTime? LastUpdateTime { get; set; }
        
        public DateTime? LastUpdateTime_Start { get; set; }
        
        public DateTime? LastUpdateTime_End { get; set; }
        
        public Boolean? Enabled { get; set; }
        
    }
}
