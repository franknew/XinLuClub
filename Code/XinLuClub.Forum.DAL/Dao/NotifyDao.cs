using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class NotifyDao : BaseDao<Notify, NotifyQueryForm, NotifyUpdateForm>
    {
        public NotifyDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public NotifyDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryNotifyLastUpdateTime", null);
        }
    }
}