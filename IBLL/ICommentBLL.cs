using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface ICommentBLL:IBaseBLL<Comment>
    {
        IQueryable<Comment> GetTop6();
        IEnumerable<view_comment> GetCommentsByGuideId(int id);
        Comment DeleteByCommentId(int commentid);
        int GetCount();
    }
}
