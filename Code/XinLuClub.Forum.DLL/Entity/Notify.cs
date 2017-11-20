using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Entity
{
    public partial class Notify : SimpleEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public string TopicID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ReplyID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? IsRead { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string UserID { get; set; }
        
    }
}