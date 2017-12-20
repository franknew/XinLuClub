using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class ReplyDao : BaseDao<Reply, ReplyQueryForm, ReplyUpdateForm>
    {
        public ReplyDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public ReplyDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryReplyLastUpdateTime", null);
        }
    }
}