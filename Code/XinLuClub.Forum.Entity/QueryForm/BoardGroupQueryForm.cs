using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Form
{
    public partial class BoardGroupQueryForm : SimpleQueryForm
    {
        public List<string> IDs { get; set;}
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public Boolean? Enabled { get; set; }
        
    }
}
