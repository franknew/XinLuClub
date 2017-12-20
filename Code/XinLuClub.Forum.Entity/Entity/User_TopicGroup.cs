using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class User_TopicGroup : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string UserID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string TopicGroupID { get; set; }
        
    }
}