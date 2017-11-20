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
    public partial class NotifyDao : SimpleDao<Notify, NotifyQueryForm, NotifyUpdateForm>
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