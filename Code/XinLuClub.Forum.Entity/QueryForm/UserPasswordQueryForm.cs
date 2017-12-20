using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class UserPasswordQueryForm : BaseQueryForm
    {
        public string ID { get; set; }
        
        public List<string> IDs { get; set;}
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
    }
}
