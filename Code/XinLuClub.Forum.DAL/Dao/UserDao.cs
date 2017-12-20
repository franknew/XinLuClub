using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class UserDao : BaseDao<User, UserQueryForm, UserUpdateForm>
    {
        public UserDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public UserDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryUserLastUpdateTime", null);
        }
    }
}