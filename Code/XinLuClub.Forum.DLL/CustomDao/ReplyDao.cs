using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinLuClub.Forum.DLL.Entity;
using XinLuClub.Forum.DLL.Form;

namespace XinLuClub.Forum.DLL.Dao
{
    public partial class ReplyDao : SimpleDao<Reply, ReplyQueryForm, ReplyUpdateForm>
    {
        public List<ReplyWithChild> QueryWithChild(ReplyQueryForm form)
        {
            return DaoHelper.QueryForList<ReplyWithChild, ReplyQueryForm>(Mapper, "Reply.QueryChild", form);
        }

        public List<ReplyWithChild> QueryFullReplyInfo(ReplyQueryForm form)
        {
            return DaoHelper.QueryForList<ReplyWithChild, ReplyQueryForm>(Mapper, "Reply.QueryFullReplyInfo", form);
        }
    }
}
