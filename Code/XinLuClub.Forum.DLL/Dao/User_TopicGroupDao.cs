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
    public partial class User_TopicGroupDao : BaseDao<User_TopicGroup, User_TopicGroupQueryForm, User_TopicGroupUpdateForm>
    {
        public User_TopicGroupDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public User_TopicGroupDao()
            : base(null)
        {
        }
        
    }
}