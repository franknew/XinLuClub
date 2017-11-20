using XinLuClub.Forum.DLL.Form;
using XinLuClub.Forum.DLL.Entity;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DLL.Dao
{
    public partial class TopicGroupDao : SimpleDao<TopicGroup, TopicGroupQueryForm, TopicGroupUpdateForm>
    {
        public TopicGroupDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public TopicGroupDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryTopicGroupLastUpdateTime", null);
        }
    }
}