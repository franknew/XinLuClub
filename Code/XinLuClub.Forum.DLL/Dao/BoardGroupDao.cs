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
    public partial class BoardGroupDao : SimpleDao<BoardGroup, BoardGroupQueryForm, BoardGroupUpdateForm>
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