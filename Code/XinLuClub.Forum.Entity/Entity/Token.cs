using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class Token : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string AccessToken { get; set; }
        
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