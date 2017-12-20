using XinLuClub.Forum.DAL;
using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOAFramework.Library.DAL;

namespace XinLuClub.Forum.DAL
{
    public partial class BoardGroupDao : BaseDao<BoardGroup, BoardGroupQueryForm, BoardGroupUpdateForm>
    {
        public BoardGroupDao(ISqlMapper mapper)
            : base(mapper)
        {
        }
        
        public BoardGroupDao()
            : base(null)
        {
        }
        
        public DateTime? QueryMaxLastUpdateTime()
        {
            return Mapper.QueryForObject<DateTime?>("QueryBoardGroupLastUpdateTime", null);
        }
    }
}