using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YueYou.Model;

namespace IDAL
{
    public partial interface ICommentDAL:IBaseDAL<Comment>
    {
        IQueryable<Comment> GetTop6();
        IEnumerable<view_comment> GetCommentsByGuideId(int id);
        Comment DeleteByCommentId(int commentid);
        int GetCount();
    }
}
