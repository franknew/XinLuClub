using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.DAL
{
    public partial class ReplyDao : BaseDao<Reply, ReplyQueryForm, ReplyUpdateForm>
    {
        public List<ReplyWithChild> QueryWithChild(ReplyQueryForm form)
        {
            return DaoHelper.QueryForList<ReplyWithChild, ReplyQueryForm>(Mapper, "Reply.QueryChild", form);
        }

        public List<ReplyWithChild> QueryFullReplyInfo(ReplyQueryForm form)
        {
            return DaoHelper.QueryForList<ReplyWithChild, ReplyQueryForm>(Mapper, "Reply.QueryFullReplyInfo", form);
        }

        public List<FullReplyInfo> QueryNotifyReply(ReplyQueryForm form)
        {
            return DaoHelper.QueryForList<FullReplyInfo, ReplyQueryForm>(Mapper, "Reply.QueryNotifyReply", form);
        }

        public int QueryNotifyReplyCount(QueryNotifyReplyForm form)
        {
            return DaoHelper.GetCount<QueryNotifyReplyForm, Reply>(Mapper, form, "Reply.QueryNotifyReply");
        }
    }
}
