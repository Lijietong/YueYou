using IDAL;
using YueYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CommentDAL : BaseDAL<Comment>, ICommentDAL
    {
        YueYouEntities db = new YueYouEntities();
        public IQueryable<Comment> GetTop6()
        {
            var comments = db.Comment.OrderByDescending(u => u.Contents_qulity).Skip(0).Take(6);
            return comments;
        }
        public IEnumerable<view_comment> GetCommentsByGuideId( int id)
        {
            var viewcomment = db.view_comment.Where(u => u.Guide_id == id);
            return viewcomment;
        }
        public Comment DeleteByCommentId(int commentid)
        {
            var comment = db.Comment.Where(u => u.Comment_id == commentid).FirstOrDefault();
            return comment;
        }
        public int GetCount()
        {
            var count = db.Comment.Count();
            return count;
        }
    }
}
