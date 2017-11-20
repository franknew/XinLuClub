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
    public partial class ReplyDao : SimpleDao<Reply, ReplyQueryForm, ReplyUpdateForm>
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