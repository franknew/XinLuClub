using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class TopicDao : BaseDao<Topic, TopicQueryForm, TopicUpdateForm>
    {
        public TopicDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public TopicDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryTopicLastUpdateTime", null);
        }
    }
}