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
    public partial class User_BoardGroupDao : BaseDao<User_BoardGroup, User_BoardGroupQueryForm, User_BoardGroupUpdateForm>
    {
        public User_BoardGroupDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public User_BoardGroupDao()
            : base(null)
        {
        }
        
    }
}