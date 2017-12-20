using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class Reply : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string Content { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string OwnerID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string ReplyID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string TopicID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string ReplyTo { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public int? Enabled { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? LastUpdateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string ReplyToID { get; set; }
        
    }
}