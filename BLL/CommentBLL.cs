using IBLL;
using IDAL;
using YueYou.Model;
using DALContainer;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public partial class CommentBLL:BaseBLL<Comment>,ICommentBLL
    {
        private ICommentDAL CommentDAL = Container.Resolve<ICommentDAL>();
        public override void SetDal()
        {
            Dal = CommentDAL;
        }
        public IQueryable<Comment>GetTop6()
        {
            var comments = CommentDAL.GetTop6();
            return comments;
        }
        public IEnumerable<view_comment>GetCommentsByGuideId(int id)
        {
            var viewcomments = CommentDAL.GetCommentsByGuideId(id);
            return viewcomments;
        }
        public Comment DeleteByCommentId(int commentid)
        {
            var comment = CommentDAL.DeleteByCommentId(commentid);
            return comment;
        }
        public int GetCount()
        {
            var count = CommentDAL.GetCount();
            return count;
        }
    }
}
