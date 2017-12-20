using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class BoardGroup : BaseEntity
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
        
        public string Description { get; set; }
        
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
        
    }
}