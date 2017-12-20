using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class TopicGroupDao : BaseDao<TopicGroup, TopicGroupQueryForm, TopicGroupUpdateForm>
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