using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DAL
{
    public partial class TopicDao : BaseDao<Topic, TopicQueryForm, TopicUpdateForm>
    {
        public List<FullTopicInfo> QueryFullTopicInfo(TopicQueryForm form)
        {
            return DaoHelper.QueryForList<FullTopicInfo, TopicQueryForm>(Mapper, "Topic.QueryFullTopicInfo", form).ToList();
        }

        public bool UpdateReplyCount(TopicQueryForm form)
        {
            return Mapper.Update("Topic.UpdateReplyCount", form) > 0;
        }

        public List<FullTopicInfo> SearchMyTopic(SearchMyTopicForm form)
        {
            return Mapper.QueryForList<FullTopicInfo>("Topic.SearchMyTopic", form).ToList();
        }
    }
}
