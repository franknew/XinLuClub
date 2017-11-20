using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Entity
{
    public partial class Token : SimpleEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? Enabled { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string UserID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ExpiredTime { get; set; }
        
    }
}