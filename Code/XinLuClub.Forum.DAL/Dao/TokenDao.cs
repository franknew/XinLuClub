using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class TokenDao : BaseDao<Token, TokenQueryForm, TokenUpdateForm>
    {
        public TokenDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public TokenDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryTokenLastUpdateTime", null);
        }
    }
}