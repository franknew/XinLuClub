using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class User : BaseEntity
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
        
        public int? Gender { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string IdentityCode { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string Mobile { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public int? Enabled { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 是否管理员
        /// </summary>
        
        public int? IsAdmin { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string RealName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public string WeiXin { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? LastUpdateTime { get; set; }
        
    }
}