using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class UserPasswordDao : BaseDao<UserPassword, UserPasswordQueryForm, UserPasswordUpdateForm>
    {
        public UserPasswordDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public UserPasswordDao()
            : base(null)
        {
        }
        
    }
}