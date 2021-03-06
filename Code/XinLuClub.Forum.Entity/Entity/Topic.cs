using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class Topic : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string Content { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? LastUpdateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string OwnerID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string LastReplierID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public int? ReplyCount { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string TopicGroupID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string BoardGroupID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public int? Enabled { get; set; }
        
    }
}