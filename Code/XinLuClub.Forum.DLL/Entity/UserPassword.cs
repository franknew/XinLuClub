using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Entity
{
    public partial class UserPassword : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        
    }
}