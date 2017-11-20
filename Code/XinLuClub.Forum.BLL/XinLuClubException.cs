using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinLuClub.Forum.BLL
{
    public class XinLuClubException : Exception
    {
        public XinLuClubException(int code, string message)
            : base(message)
        {
            this.Code = code;
        }
        public int Code { get; set; }
    }
}
