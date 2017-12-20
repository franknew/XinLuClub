using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class Notify : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }
        
        /// <summary>
        /// 测试备注
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
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? LastUpdateTime { get; set; }
        
    }
}